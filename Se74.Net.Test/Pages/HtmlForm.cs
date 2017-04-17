using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Se74.Net.Test.Context;
using Se74.Net.Elements;
using OpenQA.Selenium;

namespace Se74.Net.Test.Pages
{
    public class HtmlForm : MyBasePage<HtmlForm>
    {

        public Se74Element FormLink { get; private set; }

        public HtmlForm(MySe74Context context) : base(context)
        {
            FormLink = new Se74Element(By.XPath("//a[.='HTML Forms']"));
        }


        public HtmlForm Open()
        {
            Test.Driver.Navigate().GoToUrl(new Uri("https://www.tutorialspoint.com/html/html_forms.htm"));
            return this;
        }
    }
}
