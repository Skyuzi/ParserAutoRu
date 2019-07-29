using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;
using AngleSharp;
using AngleSharp.Parser.Html;
using AngleSharp.Dom;
using CsvExports;
using System.Net;

namespace AutoRuParser
{
    public partial class Form1 : Form
    {
        #region//Настройки интерфейса
        public Form1()
        {
            InitializeComponent();
        }

        private void CbNew_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNew.Checked == true)
            {
                cbHistory.Enabled = false;
                cbCredit.Enabled = false;
                cbDilers.Enabled = true;
                cbAll.Enabled = false;
                cbUsed.Enabled = false;
            }
            else
            {
                cbDilers.Enabled = false;
                cbHistory.Enabled = false;
                cbCredit.Enabled = false;
                cbAll.Enabled = true;
                cbUsed.Enabled = true;
            }
        }

        private void CbUsed_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUsed.Checked == true)
            {
                cbAll.Enabled = false;
                cbNew.Enabled = false;
                cbDilers.Enabled = false;
                cbHistory.Enabled = true;
                cbCredit.Enabled = true;
            }
            else
            {
                cbAll.Enabled = true;
                cbNew.Enabled = true;
                cbDilers.Enabled = false;
                cbHistory.Enabled = false;
                cbCredit.Enabled = false;
            }
        }

        private void CbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAll.Checked == true)
            {
                cbNew.Enabled = false;
                cbUsed.Enabled = false;
                cbHistory.Enabled = true;
                cbCredit.Enabled = true;
            }
            else
            {
                cbNew.Enabled = true;
                cbUsed.Enabled = true;
                cbHistory.Enabled = false;
                cbCredit.Enabled = false;
            }
        }

        private void BtnClearLog_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }
        #endregion

        HttpRequest danni = new HttpRequest();
        CookieDictionary cookies = new CookieDictionary();
        CsvExport myExport = new CsvExport();

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Thread main = new Thread(MainMethod);
            main.Start();
        }

        private void MainMethod()
        {
            int startPage = 1;  //С какой страницы начать
            int maxPage = 5;    //До какой страницы парсить
            int timeBefore = 10000;

            for (int q = startPage; q < maxPage; q++)
            {
                string url = "";

                Invoke((MethodInvoker)delegate
                {
                    if (cbAll.Checked == true)
                    {
                        url = "https://auto.ru/cars/all/?sort=fresh_relevance_1-desc";

                        if (cbHistory.Checked == true)
                            url = "https://auto.ru/cars/all/?sort=fresh_relevance_1-desc&has_history=true";

                        else if (cbCredit.Checked == true)
                            url = "https://auto.ru/cars/all/?sort=fresh_relevance_1-desc&on_credit=true";

                        else if (cbHistory.Checked == true && cbCredit.Checked == true)
                            url = "https://auto.ru/cars/all/?has_history=true&sort=fresh_relevance_1-desc&on_credit=true";
                    }

                    else if (cbNew.Checked == true)
                    {
                        url = "https://auto.ru/cars/new/?sort=fresh_relevance_1-desc";

                        if (cbDilers.Checked == false)
                            url = "https://auto.ru/cars/new/?sort=fresh_relevance_1-desc&only_official=false";
                    }

                    else if (cbUsed.Checked == true)
                    {
                        url = "https://auto.ru/cars/used/?sort=fresh_relevance_1-desc";

                        if (cbHistory.Checked == true)
                            url = "https://auto.ru/cars/used/?sort=fresh_relevance_1-desc&has_history=true";

                        else if (cbCredit.Checked == true)
                            url = "https://auto.ru/cars/used/?sort=fresh_relevance_1-desc&on_credit=true";

                        else if (cbHistory.Checked == true && cbCredit.Checked == true)
                            url = "https://auto.ru/cars/used/?has_history=true&sort=fresh_relevance_1-desc&on_credit=true";
                    }
                });

                url = url + $"&page={q}";

                var linkes = GetLinkes(url);

                var info = GetInfo(linkes);

                int linkesScore = 0;

                for (int i = 0; i < info.Count; i++)
                {
                    try
                    {
                        SaveInfo(linkes[linkesScore], info[i], info[i++], info[i++], info[i++], info[i++], info[i++], info[i++], info[i++], info[i++], info[i++], info[i++], info[i++], info[i++], info[i++], info[i++]);
                        linkesScore++;
                    }
                    catch
                    {
                        break;
                    }
                }

                myExport.ExportToFile("Cars.csv");

                Thread.Sleep(timeBefore); //Задерджка перед парсом след страницы
            }
        }

        private List<string> GetLinkes(string url)
        {
            List<string> href = new List<string>();

            danni.KeepAlive = true;
            danni.Cookies = cookies;
            danni.UserAgent = Http.ChromeUserAgent();

            var head = danni.Get(url);

            if (head.Address.ToString().Contains("showcaptcha"))
            {
                string html = danni.Get(url).ToString();

                var keys = GetKey(html);

                string[] values = keys[0].Split('_');

                string captcha = GetAnswer(values[0]);

                keys[0] = keys[0].Replace("/", "%2F");

                try
                {
                    var skipCaptcha = danni.Get($"https://auto.ru/checkcaptcha?key={keys[0]}&retpath={keys[1]}&rep={captcha}");

                    if (!skipCaptcha.Address.ToString().Contains("https://auto.ru/cars"))
                        GetLinkes(url);
                }
                catch
                {
                    GetLinkes(url);
                }
            }

            string response = danni.Get(url).ToString();
            string getCookies = danni.Get("https://matchid.adfox.yandex.ru/getcookie").ToString();

            var parser = new HtmlParser();
            var doc = parser.Parse(response);

            var linkes = doc.QuerySelectorAll("a.ListingItemTitle-module__link");

            foreach (var item in linkes)
            {
                href.Add(item.GetAttribute("href"));
            }

            return href;
        }

        private List<string> GetInfo(List<string> linkes)
        {
            List<string> info = new List<string>();

            danni.KeepAlive = true;
            danni.Cookies = cookies;
            danni.UserAgent = Http.ChromeUserAgent();

            for (int i = 0; i < linkes.Count(); i++)
            {
                string response = danni.Get(linkes[i]).ToString();

                var parser = new HtmlParser();
                var doc = parser.Parse(response);

                string city = "";

                try
                {
                    city = doc.QuerySelector("span.MetroListPlace__regionName").TextContent;
                }
                catch
                {
                    city = "Не указан";
                }

                info.Add(city);

                var information = doc.QuerySelectorAll("span.CardInfo__cell");

                int check = 0;

                foreach (var item in information)
                {
                    if (check == 0)
                    {
                        check++;
                        continue;
                    }

                    string text = item.TextContent;

                    info.Add(text);
                    check = 0;
                }
            }

            return info;
        }

        private void SaveInfo(string link, string city, string year, string probeg, string kuzov, string color, string dvigatel, string box, string privod, string rul,
            string status, string vladelec, string ptc, string tamoznya, string vin, string gosnomer)
        {
            myExport.AddRow();
            myExport["Ссылка"] = link;
            myExport["Город"] = city;
            myExport["Год выпуска"] = year;
            myExport["Пробен"] = probeg;
            myExport["Кузов"] = kuzov;
            myExport["Цвет"] = color;
            myExport["Двигатель"] = dvigatel;
            myExport["Коробка"] = box;
            myExport["Привод"] = privod;
            myExport["Руль"] = rul;
            myExport["Состояние"] = status;
            myExport["Владельцы"] = vladelec;
            myExport["ПТС"] = ptc;
            myExport["Таможня"] = tamoznya;
            myExport["VIN"] = vin;
            myExport["Госномер"] = gosnomer;
        }

        private string GetAnswer(string key)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile($"https://ext.captcha.yandex.net/image?key={key}", "captcha.jpg");
            }

            Rucaptcha.Key = "80772be92ec6b923a46970078c3ec829";
            var cap = Rucaptcha.Recognize("captcha.jpg");

            return cap;
        }

        private List<string> GetKey(string html)
        {
            List<string> keys = new List<string>();

            var parser = new HtmlParser();
            var doc = parser.Parse(html);

            var key = doc.QuerySelector("input.form__key").GetAttribute("value");
            var retpath = doc.QuerySelector("input.form__retpath").GetAttribute("value");

            keys.Add(key);
            keys.Add(retpath);

            return keys;
        }
    }
}
