using GlobalBlue.HomeWork.Context;
using Newtonsoft.Json;
using RA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBlue.HomeWork.Services
{
    public class CalculatorClient
    {
        private GbhwContext Test;


        internal CalculatorClient (GbhwContext test)
        {
            Test = test;
        }

        public decimal Calculate(int jurisdiction, decimal amount)
        {
            CalculateAnswer retString = new RestAssured()
              .Given()
                //Optional, set the name of this suite
                .Name("JsonIP Test Suite")
                //Optional, set the header parameters.  
                //Defaults will be set to application/json if none is given
                .Header("Content-Type", "application/json")
                .Header("Accept-Encoding", "gzip,deflate")
                .Host($"{Test.Config.GbHost}/")
                .Uri("refundCal.do")
                .Query("action","calculate")
                .Query("jurisdiction", $"{jurisdiction}")
                .Query("amount", $"{amount}")
              .When()
                //url
                .Get()
              .Then()
                .TestStatus("HTTP 200", x => x == 200)
                .Retrieve(RetrieveRefund) as CalculateAnswer;

            return decimal.Parse(retString.totalRefundAmount);
        }

        public string CalculateFails(int jurisdiction, string amount)
        {
            string retString = new RestAssured()
              .Given()
                //Optional, set the name of this suite
                .Name("JsonIP Test Suite")
                //Optional, set the header parameters.  
                //Defaults will be set to application/json if none is given
                .Header("Content-Type", "text/html")
                .Header("Accept-Encoding", "gzip,deflate")
                .Host($"{Test.Config.GbHost}/")
                .Uri("refundCal.do")
                .Query("action", "calculate")
                .Query("jurisdiction", $"{jurisdiction}")
                .Query("amount", $"{amount}")
              .When()
                //url
                .Get()
              .Then()
                .TestStatus("HTTP 500", x => x == 500)
                .TestHeader("text/html", "content-type", x => x.Contains("text/html"))
                //text / html; charset = UTF - 8
                   .Retrieve(RetrieveRefund) as string;

            return retString;
        }



        public CalculateAnswer RetrieveRefund(dynamic input)
        {
            CalculateAnswer retValue = JsonConvert.DeserializeObject<CalculateAnswer>(input.ToString());
            return retValue;
        }

        public string HttpError(dynamic input)
        {
            return "Error";
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class CalculateAnswer
        {
            [JsonProperty]
            public string totalRefundAmount { get; set; }
        }
    }
}
