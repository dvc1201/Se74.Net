using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se74.Net.Driver
{
    public interface IDriverProvider
    {
        IWebDriver NewDriver();
    }
}
