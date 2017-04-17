using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System.Drawing;

namespace Se74.Net.Driver
{
    public class PhantomJsProvider : IDriverProvider
    {
        public IWebDriver NewDriver()
        {
            var driverService = PhantomJSDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            driverService.LoadImages = false;
            driverService.ProxyType = "none";
            var driver = new PhantomJSDriver(driverService);
            driver.Manage().Window.Size = new Size(1920, 1080); // Size is a type in assembly "System.Drawing"
            return driver;
        }
    }
}
