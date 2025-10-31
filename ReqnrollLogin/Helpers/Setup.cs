using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollLogin.Helpers
{
    internal class Setup
    {
        public string TestUrl { get; set; }
        public string Browser { get; set; }
        public string ImplicitWait { get; set; }

        public Setup()
        {
            LoadAppSettings();
        }

        public void LoadAppSettings()
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Resources\\")
               .AddJsonFile("Appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            // Load Appsettings from configuration file or environment variables

            TestUrl = configuration["AppSettings:testurl"];
            Browser = configuration["AppSettings:browser"];
            ImplicitWait = configuration["AppSettings:implicit.wait"];
        }
    }
}
