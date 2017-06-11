using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se74.Net.Logger
{
    public 
        interface ISe74Logger
    {
        void Log(string log, params object[] list);
    }
}
