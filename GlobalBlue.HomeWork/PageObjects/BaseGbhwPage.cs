using GlobalBlue.HomeWork.Context;
using Se74.Net.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBlue.HomeWork.PageObjects
{
    public class BaseGbhwPage<T> : Se74Page<GbhwContext, T> where T : BaseGbhwPage<T>
    {
        public BaseGbhwPage(GbhwContext context) : base(context)
        {
        }
    }
}
