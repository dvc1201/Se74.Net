using GlobalBlue.HomeWork.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBlue.HomeWork.StepDefinitions
{
    public class BaseStep
    {
        protected GbhwContext Test => GbhwContext.Current;
    }
}
