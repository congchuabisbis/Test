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
using OpenQA.Selenium.Support.UI;

namespace Updateorder
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
        public void Update1()
        {
            //nhap va focus ra ngoai
            var path = "updateorder.csv";
            // Cái này để lưu danh sách test case có trong file
            var records = new List<TestCase9>();

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
                    var record = csv.GetRecord<TestCase9>();
                    records.Add(record);
                }
            }


            foreach (var record in records)
            {
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
                driver.FindElement(By.Id(record.Buttonid)).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("update__submit")).Click();
                Thread.Sleep(1000);


                if (driver.FindElements(By.CssSelector(record.Errorid)).Count > 0)
                {
                    // Lấy nội dung của error message
                    IWebElement errorMessageElement = driver.FindElement(By.CssSelector(record.Errorid));
                    string errorMessage = errorMessageElement.Text;

                    // Lấy màu nền của button
                    IWebElement buttonElement = driver.FindElement(By.Id(record.Buttonid));
                    string buttonBackgroundColor = buttonElement.GetCssValue("background-color");

                    // Kiểm tra xem message và background color có khớp với expected không
                    if (errorMessage == record.Message && buttonBackgroundColor == record.Expectedcolor)
                    {
                        record.Actual = "Passed";
                    }
                    else
                    {
                        record.Actual = $"Failed: Không khớp với thông báo lỗi hoặc màu nền của nút không đúng. Thông báo lỗi: '{errorMessage}', Màu nền của nút: '{buttonBackgroundColor}'.";
                    }
                }
                else
                {
                    // Nếu không có error id xuất hiện, gán actual là "Failed"
                    record.Actual = "Không tìm thấy thông báo lỗi";
                }

                // So sánh actual với expected và ghi kết quả vào cột Result
                record.Result = record.Actual == record.Expected ? "Passed" : "Failed";

                // Viết ngược lại các records vào file csv sau khi đã chạy xong các test case
                using (var writer = new StreamWriter(path, false, System.Text.Encoding.UTF8))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(records);
                }
                driver.Navigate().GoToUrl("https://localhost:44336/");
                {
                    IWebElement button = driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]"));
                    Actions builder = new Actions(driver);
                    builder.MoveToElement(button).Perform();
                }
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/ul[1]/li[4]/a[1]")).Click();
            }
        }

        [Test]
        public void Update2()
        {
            //nhap va focus ra ngoai
            var path = "updateorder2.csv";
            // Cái này để lưu danh sách test case có trong file
            var records = new List<TestCase10>();

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
                    var record = csv.GetRecord<TestCase10>();
                    records.Add(record);
                }
            }

            foreach (var record in records)
            {
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
                driver.FindElement(By.Id(record.Buttonid)).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("update__submit")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[1]/img[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[2]/div[3]/div[2]/div[5]/a[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
                driver.FindElement(By.Id("Email")).Click();
                driver.FindElement(By.Id("Email")).SendKeys(record.Username2);
                driver.FindElement(By.Id("Password")).Click();
                driver.FindElement(By.Id("Password")).SendKeys(record.Password2);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/button[1]")).Click();
                Thread.Sleep(1000);
                {
                    var element = driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]"));
                    Actions builder = new Actions(driver);
                    builder.MoveToElement(element).Perform();
                    Thread.Sleep(2000);
                }
                driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/ul[1]/li[1]/a[1]")).Click();
                Thread.Sleep(1000);
                var orderElement = driver.FindElement(By.CssSelector(record.Line));
                Thread.Sleep(2000);
                string orderText = orderElement.Text;
                bool containsOrderNumber = orderText.Contains(record.Idorder);
                Thread.Sleep(1000);
                bool containsStatus = orderText.Contains(record.Status);

                // Kiểm tra và ghi kết quả vào bản kiểm thử
                if (containsOrderNumber && containsStatus)
                {
                    record.Actual = "Display";
                }
                else
                {
                    record.Actual = "NoDisplay";
                }

                    // So sánh Actual với Expected và ghi kết quả vào cột Result
                    record.Result = record.Actual == record.Expected ? "Passed" : "Failed";

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

        

