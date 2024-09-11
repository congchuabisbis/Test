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
using System.Linq;

namespace Timkiem
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
        public void Timkiem1()
        {
            //nhap va focus ra ngoai
            var path = "Search.csv";
            // Cái này để lưu danh sách test case có trong file
            var records = new List<TestCase8>();

            // Cho phep du lieu duoc null
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
            };

            // Đọc data từ file csv
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader(); // Dòng này để báo file bỏ qua dòng đầu tiên là tên các thuộc tính, tức là test case sẽ bắt đầu từ dòng thứ 2
                while (csv.Read())
                {
                    var record = csv.GetRecord<TestCase8>();
                    records.Add(record);
                }
            }
            foreach (var record in records)
            {
                //Timkiemthanhcong
                driver.Navigate().GoToUrl("https://localhost:44336/");
                driver.Manage().Window.Size = new System.Drawing.Size(1536, 816);
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
                driver.FindElement(By.Id("Email")).Click();
                driver.FindElement(By.Id("Email")).SendKeys(record.Username);
                driver.FindElement(By.Id("Password")).Click();
                driver.FindElement(By.Id("Password")).SendKeys(record.Password);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/button[1]")).Click();
                driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[6]/a[1]")).Click();
                driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[10]/a[1]/span[2]")).Click();
                driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/input[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/input[1]")).SendKeys(record.Number);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/input[1]")).SendKeys(Keys.Enter);
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[1]/img[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[2]/div[5]/a[1]")).Click();
                Thread.Sleep(1000);

                if (driver.PageSource.Contains(record.Number))
                {
                    record.Actual = "Display";
                }
                else
                {
                    record.Actual = "NoDisplay";
                }

                // So sánh kết quả thực tế và kết quả mong đợi
                if (record.Actual == record.Expected)
                {
                    record.Result = "Passed";
                }
                else
                {
                    record.Result = "Failed";
                }


                // Viết ngược lại các records vào file csv sau khi đã chạy xong các test case
                using (var writer = new StreamWriter(path, false, System.Text.Encoding.UTF8))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(records);
                }

            }
        }
    }
    }

       
           
          