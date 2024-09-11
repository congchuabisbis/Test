using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using Test1;
using System.Timers;

namespace Dnhap
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
        public void Dnhap()
        {
            var path = "testdnhap.csv";
            // Cái này để lưu danh sách test case có trong file
            var records = new List<TestCase3>();

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
                    var record = csv.GetRecord<TestCase3>();
                    records.Add(record);
                }
            }
            foreach (var record in records)
            {
                driver.Navigate().GoToUrl("https://localhost:44336/");
                driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);
                driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
                driver.FindElement(By.Id("Email")).Click();
                driver.FindElement(By.Id("Email")).SendKeys(record.Username);
                driver.FindElement(By.Id("Password")).Click();
                driver.FindElement(By.Id("Password")).SendKeys(record.Password);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/button[1]")).Click();
                string actual = driver.FindElement(By.Id(record.Errorid)).Text;
                string testResult = actual.Equals(record.Expected) ? "Passed" : "Failed";

                record.Actual = actual;
                record.Result = testResult;
            }
            // Viết ngược lại các records vào file csv sau khi đã chạy xong các test case
            using (var writer = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }

        [Test]
        public void Dnhaprole()
        {
            var path = "dnhaprole.csv";
            // Cái này để lưu danh sách test case có trong file
            var records = new List<TestCase4>();

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
                    var record = csv.GetRecord<TestCase4>();
                    records.Add(record);
                }
            }

            foreach (var record in records)
            {
                driver.Navigate().GoToUrl("https://localhost:44336/");
                driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);
                driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
                driver.FindElement(By.Id("Email")).Click();
                driver.FindElement(By.Id("Email")).SendKeys(record.Username);
                driver.FindElement(By.Id("Password")).Click();
                driver.FindElement(By.Id("Password")).SendKeys(record.Password);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/button[1]")).Click();
                Thread.Sleep(2000);
                {
                    var element = driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]"));
                    Actions builder = new Actions(driver);
                    builder.MoveToElement(element).Perform();
                    Thread.Sleep(2000);
                }
                driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/ul[1]/li[4]/a[1]")).Click();

                bool isAdminPanelDisplayed = driver.PageSource.Contains("ADMIN PANEL");

                // Đặt kết quả tương ứng cho case
                string actual = isAdminPanelDisplayed ? "Passed" : "Failed";
                string testResult = actual.Equals(record.Expected) ? "Passed" : "Failed";

                // Lưu kết quả vào record
                record.Actual = actual;
                record.Result = testResult;
            }
            // Viết ngược lại các records vào file csv sau khi đã chạy xong các test case
            using (var writer = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }

        }

        [Test]
        public void Validate()
        {

            var path = "dnhapvalidate.csv";
            // Cái này để lưu danh sách test case có trong file
            var records = new List<TestCase5>();

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
                    var record = csv.GetRecord<TestCase5>();
                    records.Add(record);
                }
            }
             foreach(var record in records)
            {
                driver.Navigate().GoToUrl("https://localhost:44336/");
                driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);
                driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
                driver.FindElement(By.Id("Email")).Click();
                driver.FindElement(By.Id("Email")).SendKeys(record.Username);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]")).Click();
                driver.FindElement(By.Id("Password")).Click();
                driver.FindElement(By.Id("Password")).SendKeys(record.Password);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]")).Click();
                Thread.Sleep(500); 

                try
                {
                    // Kiểm tra xem lỗi có xuất hiện hay không
                    var errorElement = driver.FindElement(By.Id(record.Errorid));

                    // Ghi nội dung lỗi vào record.Actual
                    record.Actual = errorElement.Text;

                    // So sánh nội dung lỗi với nội dung mong đợi
                    if (errorElement.Text == record.Expected)
                    {
                        record.Result = "Passed";
                    }
                    else
                    {
                        record.Result = "Failed";
                    }
                }
                catch (NoSuchElementException)
                {
                    // Nếu không tìm thấy phần tử lỗi, ghi Actual là "Failed"
                    record.Actual = "Failed";
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