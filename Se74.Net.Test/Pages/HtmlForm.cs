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
        public TextInput FirstName { get; private set; }
        public TextInput LastName { get; private set; }
        public CheckBox Maths { get; private set; }
        public CheckBox Physics { get; private set; }

        public HtmlForm(MySe74Context context) : base(context)
        {
            FormLink = new Se74Element(By.XPath("//a[.='HTML Forms']"));
            FirstName = new TextInput(By.Name("first_name"));
            LastName = new TextInput(By.Name("first_name"));
            Maths = new CheckBox(By.Name("maths"));
            Physics = new CheckBox(By.Name("physics"));
        }


        public HtmlForm Open()
        {
            Test.Driver.Navigate().GoToUrl(new Uri("https://www.tutorialspoint.com/html/html_forms.htm"));
            return this;
        }
    }
}
