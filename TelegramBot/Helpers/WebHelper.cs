using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Helpers
{
    public static class WebHelper
    {
        public static T Get<T>(string url)
        {
            try
            {
                var request = WebRequest.Create(url);
                var response = request.GetResponse();

                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    string responseString = streamReader.ReadToEnd();

                    var responceData = JsonConvert.DeserializeObject<T>(responseString);

                    return responceData;
                }
            }
            catch(WebException)
            {
                throw;
            }
        }
    }
}
