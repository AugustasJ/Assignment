using System.IO;
using System.Net;
using System.Xml.Linq;

namespace HomeAssignmentLibrary.API.WebServices
{
    public class VilibBaseRateProvider
    {
        public static decimal GetVilibRate(string baseRateCode)
        {
            string xml = string.Empty;
            string url = @"http://www.lb.lt/webservices/VilibidVilibor/VilibidVilibor.asmx/getLatestVilibRate?RateType=" + baseRateCode;
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                xml = reader.ReadToEnd();
            }

            var rootElement = XElement.Parse(xml);
            var elementValue = rootElement.Value;
            decimal latestBaseRateValue = decimal.Parse(elementValue);

            return latestBaseRateValue;
        }
    }
}