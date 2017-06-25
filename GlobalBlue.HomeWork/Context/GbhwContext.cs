using GlobalBlue.HomeWork.PageObjects;
using GlobalBlue.HomeWork.Services;
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


        public GbhwCalculator Calculator { get; private set; }
        public CalculatorClient CalculatorService { get; private set; }
        public GbhwConfig Config { get; private set; }


        private GbhwContext(GbhwConfig config)
        {
            Config = config;
            Calculator = new GbhwCalculator(this);
            CalculatorService = new CalculatorClient(this);
        }


        public static void New()
        {
            _context = new GbhwContext(new GbhwConfig());
        }


        public static void Release()
        {
            _context = null;
        }
    }
}
