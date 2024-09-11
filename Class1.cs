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

namespace Test
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
        public void Dangky()
        {

            //BỎ TRỐNG INPUT VÀ NHẤN ĐĂNG KÝ
            var path = "casedky.csv";
            // Cái này để lưu danh sách test case có trong file
            var records = new List<TestCase>();

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
                    var record = csv.GetRecord<TestCase>();
                    records.Add(record);
                }
            }

            // Vòng lặp từng test case
            foreach (var record in records)
            {
                driver.Navigate().GoToUrl("https://localhost:44336/");
                driver.Manage().Window.Size = new System.Drawing.Size(1536, 816);
                Thread.Sleep(500);
                IWebElement element = driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(element).Perform();
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/ul[1]/li[1]/a[1]")).Click();
                driver.FindElement(By.Id("Email")).Click();
                driver.FindElement(By.Id("Email")).SendKeys(record.Email);

                driver.FindElement(By.Id("Name")).Click();
                driver.FindElement(By.Id("Name")).SendKeys(record.HoTen);

                driver.FindElement(By.Id("PhoneNumber")).Click();
                driver.FindElement(By.Id("PhoneNumber")).SendKeys(record.Phone);

                driver.FindElement(By.Id("Password")).Click();
                driver.FindElement(By.Id("Password")).SendKeys(record.Password);

                driver.FindElement(By.Id("PasswordConfirm")).Click();
                driver.FindElement(By.Id("PasswordConfirm")).SendKeys(record.ConfirmPass);

                driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[6]/button[1]")).Click();

                string actual = "Failed"; // Mặc định Actual = Failed

                try
                {
                    // Kiểm tra xem có xuất hiện errorid hay không
                    string errorIdText = driver.FindElement(By.Id(record.Errorid)).Text;

                    if (!string.IsNullOrEmpty(errorIdText))
                    {
                        actual = errorIdText; // Nếu có, ghi nội dung vào Actual
                    }
                }
                catch (NoSuchElementException)
                {
                    // Nếu không tìm thấy errorid, Actual vẫn là Failed
                }

                // So sánh Actual với Expected
                string testResult = actual.Equals(record.Expected) ? "Passed" : "Failed";

                // Ghi kết quả vào record
                record.Actual = actual;
                record.Result = testResult;
            }

            Thread.Sleep(3000);

            // Viết ngược lại các records vào file csv sau khi đã chạy xong các test case
            using (var writer = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }




        [Test]
        public void TestDky()
        {
            //Dang ky thanh cong và dnhap voi tai khoan vua dky
            var path = "testdky.csv";
            // Cái này để lưu danh sách test case có trong file
            var records = new List<TestCase2>();

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
                    var record = csv.GetRecord<TestCase2>();
                    records.Add(record);
                }
            }

            foreach (var record in records)
            {
                driver.Navigate().GoToUrl("https://localhost:44336/");
                driver.Manage().Window.Size = new System.Drawing.Size(1536, 816);
                Thread.Sleep(500);

                if (record.PageTest == "DangKy")
                {
                    IWebElement element = driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]"));
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(element).Perform();
                    Thread.Sleep(500);
                    driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/ul[1]/li[1]/a[1]")).Click();
                    driver.FindElement(By.Id("Email")).Click();
                    driver.FindElement(By.Id("Email")).SendKeys(record.Email);

                    driver.FindElement(By.Id("Name")).Click();
                    driver.FindElement(By.Id("Name")).SendKeys(record.HoTen);

                    driver.FindElement(By.Id("PhoneNumber")).Click();
                    driver.FindElement(By.Id("PhoneNumber")).SendKeys(record.Phone);

                    driver.FindElement(By.Id("Password")).Click();
                    driver.FindElement(By.Id("Password")).SendKeys(record.Password);

                    driver.FindElement(By.Id("PasswordConfirm")).Click();
                    driver.FindElement(By.Id("PasswordConfirm")).SendKeys(record.ConfirmPass);

                    driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[6]/button[1]")).Click();
                    Thread.Sleep(5000);

                }
                else if (record.PageTest == "DangNhap")
                {
                    driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]")).Click();
                    driver.FindElement(By.Id("Email")).Click();
                    driver.FindElement(By.Id("Email")).SendKeys(record.Email);

                    driver.FindElement(By.Id("Password")).Click();
                    driver.FindElement(By.Id("Password")).SendKeys(record.Password);

                    driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[1]/div[1]/form[1]/div[4]/button[1]")).Click();
                    Thread.Sleep(3000);
                }

                // Kiểm tra xem việc chuyển hướng đã thành công đến trang đích mong muốn hay không
                bool successfullyRedirected = true;

                if (record.Expected == "Chuyển thành công đến trang đăng nhập")
                {
                    successfullyRedirected = driver.Url == "https://localhost:44336/login?returnUrl=https%3A%2F%2Flocalhost%3A44336%2Fregister";

                }
                else if (record.Expected == "Chuyển thành công qua trang chính")
                {
                    successfullyRedirected = driver.Url == "https://localhost:44336/";
                }

                if (successfullyRedirected)
                {
                    // Nếu chuyển hướng thành công, ghi kết quả vào record
                    record.Result = "Passed";
                }
                else
                {
                    // Nếu không chuyển hướng thành công, ghi kết quả vào record
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




        [Test]
        public void Validate()
        {
            //nhap va focus ra ngoai
            var path = "dkyvalidate.csv";
            // Cái này để lưu danh sách test case có trong file
            var records = new List<TestCase6>();

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
                    var record = csv.GetRecord<TestCase6>();
                    records.Add(record);
                }
            }

            foreach (var record in records)
            {
                driver.Navigate().GoToUrl("https://localhost:44336/");
                driver.Manage().Window.Size = new System.Drawing.Size(1536, 816);
                Thread.Sleep(500);
                IWebElement element = driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(element).Perform();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/ul[1]/li[1]/a[1]")).Click();
                driver.FindElement(By.Id("Email")).Click();
                driver.FindElement(By.Id("Email")).SendKeys(record.Email);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]")).Click();
                Thread.Sleep(1000);

                driver.FindElement(By.Id("Name")).Click();
                driver.FindElement(By.Id("Name")).SendKeys(record.HoTen);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]")).Click();
                Thread.Sleep(1000);

                driver.FindElement(By.Id("PhoneNumber")).Click();
                driver.FindElement(By.Id("PhoneNumber")).SendKeys(record.Phone);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]")).Click();
                Thread.Sleep(1000);

                driver.FindElement(By.Id("Password")).Click();
                driver.FindElement(By.Id("Password")).SendKeys(record.Password);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]")).Click();
                Thread.Sleep(1000);

                driver.FindElement(By.Id("PasswordConfirm")).Click();
                driver.FindElement(By.Id("PasswordConfirm")).SendKeys(record.ConfirmPass);
                driver.FindElement(By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]")).Click();
                Thread.Sleep(1000);

                try
                {
                    // Kiểm tra xem lỗi có xuất hiện hay không
                    var errorElement = driver.FindElement(By.Id(record.Error));

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
            Thread.Sleep(3000);
        }




        [Test]
        public void Validate2()
        {
            //KIEM TRA XEM TRONG QUA TRINH NHAP SAI DINH DANG CO THONG BAO KHONG
            var path = "dkyvalidate2.csv";
            // Cái này để lưu danh sách test case có trong file
            var records = new List<TestCase7>();

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
                    var record = csv.GetRecord<TestCase7>();
                    records.Add(record);
                }
            }

            foreach (var record in records)
            {
                driver.Navigate().GoToUrl("https://localhost:44336/");
                driver.Manage().Window.Size = new System.Drawing.Size(1536, 816);
                Thread.Sleep(500);
                IWebElement element = driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/a[1]"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(element).Perform();
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html[1]/body[1]/header[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/ul[1]/li[7]/ul[1]/li[1]/a[1]")).Click();

                // Trường hợp kiểm tra cho trường Email
                driver.FindElement(By.Id("Email")).SendKeys(record.Email);
                Thread.Sleep(1000);

                // Kiểm tra lỗi cho trường Email
                try
                {
                    var errorElement = driver.FindElement(By.Id(record.Errorid));
                    record.Actual = errorElement.Text;
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
                    record.Actual = "Failed";
                    record.Result = "Failed";
                }
                driver.FindElement(By.Id("Email")).Clear();



                // Trường hợp kiểm tra cho trường Phone
                driver.FindElement(By.Id("PhoneNumber")).SendKeys(record.Phone);
                Thread.Sleep(1000);

                // Kiểm tra lỗi cho trường phone
                try
                {
                    var errorElement = driver.FindElement(By.Id(record.Errorid));
                    record.Actual = errorElement.Text;
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
                    record.Actual = "Failed";
                    record.Result = "Failed";
                }

                driver.FindElement(By.Id("PhoneNumber")).Clear();
                Thread.Sleep(1000);
                

                // Trường hợp kiểm tra cho trường Pass
                driver.FindElement(By.Id("Password")).SendKeys(record.Password);

                // Kiểm tra lỗi cho trường Pass
                try
                {
                    var errorElement = driver.FindElement(By.Id(record.Errorid));
                    record.Actual = errorElement.Text;
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
                    record.Actual = "Failed";
                    record.Result = "Failed";
                }
                driver.FindElement(By.Id("Password")).Clear();


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
    



