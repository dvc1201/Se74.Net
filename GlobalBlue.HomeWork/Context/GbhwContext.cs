using Se74.Net.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBlue.HomeWork.Context
{
    public class GbhwContext : Se74Context
    {
        private static GbhwContext _context;

        public static GbhwContext Current => _context;


        private GbhwContext()
        {

        }


        public static void New()
        {
            _context = new GbhwContext();
        }


        public static void Release()
        {
            _context = null;
        }
    }
}
