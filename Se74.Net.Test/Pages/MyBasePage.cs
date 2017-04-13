using Se74.Net.Context;
using Se74.Net.Test.Context;
using Se74.Net.Test.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se74.Net.Test.Pages
{
    public class MyBasePage<P> : Se74Page<MySe74Context, P> where P : MyBasePage<P>
    {

        public MyBasePage(MySe74Context context) : base(context)
        {
        }
    }
}
