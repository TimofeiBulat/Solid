using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Helpers;
using TelegramBot.Models.WeatherModel;
using TelegramBot.Settings;

namespace TelegramBot.Services
{
    class WeatherService
    {
        public string GetWeatherForCity(string city)
        {
            var url = BotSettings._weatherServiceUrl;
            var weatherApiKey = BotSettings._weatherApiKey;

            var formattedCity = WebUtility.UrlEncode(city);
            var formattedUrl = string.Format(url, formattedCity, weatherApiKey);

            try
            {
                return WebHelper.Get<WeatherDTO>(formattedUrl).ToString();
            }
            catch(WebException)
            {
                return $"Service unavaliable";
            }
                      
        }
    }
}
