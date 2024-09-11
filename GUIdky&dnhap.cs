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

namespace GUI

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
        public void gui1()
        {
            //quenmatkhau
            driver.Navigate().GoToUrl("https://localhost:44336/");
            driver.Manage().Window.Size = new System.Drawing.Size(1536, 816);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div[9]/div/div/div/div/form/div[2]/a")).Click();
            Thread.Sleep(1000);
            // Kiểm tra xem URL sau khi nhấn có chuyển hướng đúng không
            string expectedUrl = "https://localhost:44336/forgot_password";
            string actualUrl = driver.Url;
            Assert.That(expectedUrl.Contains(actualUrl));

        }

        [Test]
        public void gui2()
        {
            //nút đăng nhập ở trang quên mật khẩu
            driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[3]/a[1]")).Click();
            Thread.Sleep(1000);
            string expectedUrl = "https://localhost:44336/login?returnUrl=https%3A%2F%2Flocalhost%3A44336%2Fforgot_password";
            string actualUrl = driver.Url;
            Assert.That(expectedUrl.Contains(actualUrl));
        }

        [Test]
        public void gui3()
        {
            //nut dang ky o trang dang nhap
            driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[5]/a[1]")).Click();
            Thread.Sleep(1000);
            string expectedUrl = "https://localhost:44336/register";
            string actualUrl = driver.Url;
            Assert.That(expectedUrl.Contains(actualUrl));
        }

        [Test]
        public void gui4()
        {
            Thread.Sleep(1000);
            //nut dang nhap o trang dang ky
            driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[7]/a[1]")).Click();
            Thread.Sleep(1000);
            string expectedUrl = "https://localhost:44336/login?returnUrl=https%3A%2F%2Flocalhost%3A44336%2Fregister";
            string actualUrl = driver.Url;
            Assert.That(expectedUrl.Contains(actualUrl));
        }

    }
}