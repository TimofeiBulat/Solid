using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Models.WeatherModel
{
    class WeatherDTO
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set;}
        public Main Main { get; set; }
        public string Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set;}
        public string Dt { get; set; }
        public Sys Sys { get; set; }  
        public long Id { get; set; }
        public string Name { get; set; }
        public long Code { get; set; }

        public override string ToString()
        {
            return $"Temperature in {this.Name} = {this.Main.Temp}";
        }
    }  
}
