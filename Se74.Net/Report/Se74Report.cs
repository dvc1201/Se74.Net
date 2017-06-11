using Se74.Net.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se74.Net.Report
{
    public class Se74Report
    {
        private static Se74Report report;
        private ISe74Logger logger;

        private Se74Report(ISe74Logger logger)
        {
            this.logger = logger;
        }

        public static Se74Report Current => report;

        public static void New(ISe74Logger logger)
        {
            report = new Se74Report(logger);
        }

        public static void Release()
        {
            report = null;
        }


        public void Log(string log, params object[] list)
        {
            logger.Log(log, list);
        }

    }
}
