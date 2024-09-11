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

namespace TestGUIAdmin
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
        public void URL1()
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
            // Nhấn vào nút "Sản phẩm"
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[4]/a[1]")).Click();
            // Kiểm tra xem URL sau khi nhấn có chuyển hướng đúng không
            string expectedUrl = "https://localhost:44336/Admin/ProductsAdmin";
            string actualUrl = driver.Url;

           Assert.That(expectedUrl.Contains(actualUrl));
        }


        [Test]
        public void URL2()
        {
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[1]/img[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[2]/div[5]/a[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("admin@gmail.com");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("Phungnek123!");
            driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/button[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[6]/a[1]")).Click();
            driver.FindElement(By.CssSelector("#\\#kt_aside_menu > .menu-item:nth-child(5) .menu-title")).Click();
            // Kiểm tra xem URL sau khi nhấn có chuyển hướng đúng không
            string expectedUrl = "https://localhost:44336/Admin/Brands";
            string actualUrl = driver.Url;

            Assert.That(expectedUrl.Contains(actualUrl));
        }


        [Test]
        public void URL3()
        {
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[1]/img[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[2]/div[5]/a[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("admin@gmail.com");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("Phungnek123!");
            driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/button[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[6]/a[1]")).Click();
            driver.FindElement(By.CssSelector(".menu-item:nth-child(6) .menu-title")).Click();
            // Kiểm tra xem URL sau khi nhấn có chuyển hướng đúng không
            string expectedUrl = "https://localhost:44336/Admin/Genres";
            string actualUrl = driver.Url;

            Assert.That(expectedUrl.Contains(actualUrl));
        }


        [Test]
        public void URL4()
        {
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[1]/img[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[2]/div[5]/a[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("admin@gmail.com");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("Phungnek123!");
            driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/button[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[6]/a[1]")).Click();
            driver.FindElement(By.CssSelector(".menu-item:nth-child(7) .menu-title")).Click();
            // Kiểm tra xem URL sau khi nhấn có chuyển hướng đúng không
            string expectedUrl = "https://localhost:44336/Admin/Feedbacks";
            string actualUrl = driver.Url;

            Assert.That(expectedUrl.Contains(actualUrl));
        }


        [Test]
        public void URL5()
        {
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[1]/img[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[2]/div[5]/a[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("admin@gmail.com");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("Phungnek123!");
            driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/button[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[6]/a[1]")).Click();
            driver.FindElement(By.CssSelector(".menu-item:nth-child(8) .menu-title")).Click();
            // Kiểm tra xem URL sau khi nhấn có chuyển hướng đúng không
            string expectedUrl = "https://localhost:44336/Admin/Discounts";
            string actualUrl = driver.Url;

            Assert.That(expectedUrl.Contains(actualUrl));
        }


        [Test]
        public void URL6()
        {
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[1]/img[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[2]/div[5]/a[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("admin@gmail.com");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("Phungnek123!");
            driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/button[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[6]/a[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[10]/a[1]/span[2]")).Click();
            // Kiểm tra xem URL sau khi nhấn có chuyển hướng đúng không
            string expectedUrl = "https://localhost:44336/Admin/Orders";
            string actualUrl = driver.Url;

            Assert.That(expectedUrl.Contains(actualUrl));
        }

        [Test]
        public void URL7()
        {
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[1]/img[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[2]/div[5]/a[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("admin@gmail.com");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("Phungnek123!");
            driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/button[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[6]/a[1]")).Click();
            driver.FindElement(By.LinkText("Tài khoản")).Click();
            // Kiểm tra xem URL sau khi nhấn có chuyển hướng đúng không
            string expectedUrl = "https://localhost:44336/Admin/Auth";
            string actualUrl = driver.Url;

            Assert.That(expectedUrl.Contains(actualUrl));
        }


        [Test]
        public void URL8()
        {
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[1]/img[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[2]/div[5]/a[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("admin@gmail.com");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("Phungnek123!");
            driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/button[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[6]/a[1]")).Click();
            driver.FindElement(By.CssSelector(".menu-item:nth-child(13) .menu-title")).Click();

            // Kiểm tra xem URL sau khi nhấn có chuyển hướng đúng không
            string expectedUrl = "https://localhost:44336/Admin/History";
            string actualUrl = driver.Url;

            Assert.That(expectedUrl.Contains(actualUrl));
        }


        [Test]
        public void URL9()
        {
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[1]/img[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[2]/div[5]/a[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("admin@gmail.com");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("Phungnek123!");
            driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/button[1]")).Click();
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[6]/a[1]")).Click();
            driver.FindElement(By.LinkText("Email")).Click();
            // Kiểm tra xem URL sau khi nhấn có chuyển hướng đúng không
            string expectedUrl = "https://localhost:44336/Admin/Email";
            string actualUrl = driver.Url;

            Assert.That(expectedUrl.Contains(actualUrl));
        }
       
    }
}