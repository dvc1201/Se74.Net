using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Se74.Net.Driver
{
    public class ChromeProvider : IDriverProvider
    {

        IWebDriver IDriverProvider.NewDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            var driver = new ChromeDriver(options);
            return driver;
        }
    }
}
