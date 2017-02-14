using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Models.CurrencyModel;
using TelegramBot.Helpers;
using TelegramBot.Settings;

namespace TelegramBot.Services
{
    public class CurrencyServise
    {
        public string GetRate(string currencyAbbr, DateTime date)
        {
            var format = "yyyy-MM-dd";
            var url = BotSettings._currencyServiceUrl;

            var formattedAbbr = string.IsNullOrEmpty(currencyAbbr) ? "USD" : currencyAbbr;
            var formattedDate = date == DateTime.MinValue ? DateTime.Now.ToString(format) : date.ToString(format);

            var formattedUrl = String.Format(url, formattedAbbr, formattedDate);

            try
            {
                return WebHelper.Get<Rate>(formattedUrl).ToString();
            }
            catch(WebException)
            {
                return $"Invalid query '/currency {currencyAbbr} {formattedDate}' or service unavaliable";
            }            
        }
    }
}
