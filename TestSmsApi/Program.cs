using System;
using System.IO;
using System.Net;
using System.Text;

namespace TestSmsApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string APIKey = "562fddfb";
            string APISecret = "AkcfUFgHXInAQoJ7";
            string toNumber = "+905350619512";
            string messageText = "Elen Koçak'tan Selamlar";

            string url = string.Format("https://rest.nexmo.com/sms/json?api_key={0}&api_secret={1}&to={2}&from=NEXMO&text={3}", APIKey, APISecret, toNumber, messageText);

            HttpWebRequest request= (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            using (HttpWebResponse response=(HttpWebResponse)request.GetResponse())
            {
                using (Stream stream=response.GetResponseStream())
                {
                    StreamReader reader=new StreamReader(stream, Encoding.UTF8);
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            Console.ReadLine();
        }
    }
}
