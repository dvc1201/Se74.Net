using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Se74.Net.Elements
{
    public class SelectTag : Se74Element
    {
        public SelectTag(By by, string name = "", string comment = "") : base(by, name, comment)
        {
        }
    }
}
