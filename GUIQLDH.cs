using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using OpenQA.Selenium.Interactions;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using Test1;
using System.Timers;

namespace GuiQLDH
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Khởi tạo driver ở đây
            driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Kiểm tra xem driver có tồn tại không trước khi giải phóng
            if (driver != null)
            {
                // Đóng driver ở đây
                driver.Quit();
            }
        }


        [Test]
        public void Buttonhover()
        {
            driver.Navigate().GoToUrl("https://localhost:44336/");
            driver.Manage().Window.Size = new System.Drawing.Size(1536, 816);
            Thread.Sleep(500);
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("admin@gmail.com");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("Phungnek123!");
            driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/button[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[6]/a[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[10]/a[1]/span[2]")).Click();
            {
                IWebElement button = driver.FindElement(By.Id("on_process_btn_141"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(button).Perform();

                // Lấy màu của nút khi hover
                string hoverColor = button.GetCssValue("background-color");

                // So sánh với màu mong muốn
                string expectedColor = "rgba(114, 57, 234, 1)";
                Assert.That(hoverColor, Is.EqualTo(expectedColor), "Màu của nút khi hover không khớp");
            }
        }

        [Test]
        public void Buttonhover2()
        {
            {
                IWebElement button = driver.FindElement(By.Id("comlpleted_btn_147"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(button).Perform();

                // Lấy màu của nút khi hover
                string hoverColor = button.GetCssValue("background-color");

                // So sánh với màu mong muốn
                string expectedColor = "rgba(80, 205, 137, 1)";
                Assert.That(hoverColor, Is.EqualTo(expectedColor), "Màu của nút khi hover không khớp");
            }

        }

        [Test]
        public void Buttonhover3()
        {
            {
                IWebElement button = driver.FindElement(By.Id("waiting_btn_158"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(button).Perform();

                // Lấy màu của nút khi hover
                string hoverColor = button.GetCssValue("background-color");

                // So sánh với màu mong muốn
                string expectedColor = "rgba(255, 199, 0, 1)";
                Assert.That(hoverColor, Is.EqualTo(expectedColor), "Màu của nút khi hover không khớp");
            }

        }


        [Test]
        public void Click1()
        {
            //Click nút next
            driver.Navigate().GoToUrl("https://localhost:44336/Admin/Orders");
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".next")).Click();
            Thread.Sleep(1000);
            string expectedUrl = "https://localhost:44336/Admin/Orders?page=2";
            string actualUrl = driver.Url;
            Assert.That(expectedUrl.Contains(actualUrl));
        }

        [Test]
        public void Click2()
        {
            //Click nút prev
            driver.FindElement(By.CssSelector(".previous")).Click();
            Thread.Sleep(1000);
            string expectedUrl = "https://localhost:44336/Admin/Orders?page=1";
            string actualUrl = driver.Url;
            Assert.That(expectedUrl.Contains(actualUrl));
        }

       
        [Test]
        public void Click3()
        {
            Thread.Sleep(1000);
            //Click thùng rác
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/a[1]")).Click();
            Thread.Sleep(1000);
            string expectedUrl = "https://localhost:44336/Admin/Orders/Trash";
            string actualUrl = driver.Url;
            Assert.That(expectedUrl.Contains(actualUrl));
        }

        [Test]
        public void Click4()
        { 
            //Click nút Quay lại ở Thùng rác
            driver.FindElement(By.CssSelector("#kt_content > div.d-flex.flex-column-fluid > div > div > div.card-header.border-0.pt-6 > div.card-toolbar > div > a")).Click();
            Thread.Sleep(1000);
            string expectedUrl2 = "https://localhost:44336/Admin/Orders";
            string actualUrl2 = driver.Url;
            Assert.That(expectedUrl2.Contains(actualUrl2));
            Thread.Sleep(1000);

        }

        [Test]
        public void Click5()
        {
            //Click vào nút hành động
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/table[1]/tbody[1]/tr[3]/td[7]/a[1]")).Click();
            Thread.Sleep(1000);
            bool isFirstButtonDisplayed = driver.FindElements(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/table[1]/tbody[1]/tr[3]/td[7]/div[1]/div[1]/a[1]")).Count > 0;
            bool isSecondButtonDisplayed = driver.FindElements(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/table[1]/tbody[1]/tr[3]/td[7]/div[1]/div[2]/a[1]")).Count > 0;
            Assert.That(isFirstButtonDisplayed && isSecondButtonDisplayed);
        }
       
        [Test]
        public void Click6()
        {
            //Click nút chi tiết đơn 155
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/table[1]/tbody[1]/tr[3]/td[7]/div[1]/div[1]/a[1]")).Click();
            Thread.Sleep(1000);
            string expectedUrl = "https://localhost:44336/Admin/Orders/Details/155";
            string actualUrl = driver.Url;
            Assert.That(expectedUrl.Contains(actualUrl));
            Thread.Sleep(1000);
        }

        [Test]
        public void Click7()
        {
            //Click nút Lịch sử mua hàng
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[2]/a[1]")).Click();
            Thread.Sleep(1000);
            bool isElementPresent = driver.FindElements(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/div[1]/div[1]/div[1]/div[1]/h2[1]")).Count > 0;

            Assert.That(isElementPresent);
        }

        
    }

    }
