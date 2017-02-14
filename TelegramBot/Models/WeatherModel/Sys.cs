using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Models.WeatherModel
{
    public class Sys
    {
        public int Type { get; set; }
        public long Id { get; set; }
        public string Message { get; set; }
        public string Country { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }

    }
}
