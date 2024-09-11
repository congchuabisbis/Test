using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class TestCase
    {
        public string Email { get; set; } = "";
        public string HoTen { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Password { get; set; } = "";
        public string ConfirmPass { get; set; } = "";
        public string Errorid { get; set; } = "";
        public string Expected { get; set; } = "";
        public string Actual { get; set; } = "";
        public string Result { get; set; } = "";
    }
   

}
