using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBlue.HomeWork.Context;

namespace GlobalBlue.HomeWork.PageObjects
{
    public class GbhwCalculator : BaseGbhwPage<GbhwCalculator>
    {
        public GbhwCalculator(GbhwContext context) : base(context)
        {
        }

        public GbhwCalculator Open()
        {
            this.Driver.Navigate().GoToUrl(Test.Config.CalculatorUrl);
            return this;
        }
    }
}
