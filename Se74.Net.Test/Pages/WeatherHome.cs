using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Se74.Net.Test.Context;

namespace Se74.Net.Test.Pages
{
    public class WeatherHome : MyBasePage<WeatherHome>
    {
        public WeatherHome(MySe74Context context) : base(context)
        {
        }

        public WeatherHome Open()
        {
            Driver.Navigate().GoToUrl(new Uri("http://www.weather-forecast.com/"));
            return this;
        }
    }
}
