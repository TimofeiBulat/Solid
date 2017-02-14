using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Models.CurrencyModel
{
    public class Rate
    {
        public int Cur_ID { get; set; }
        public DateTime Date { get; set; }
        public string Cur_Abbreviation { get; set; }
        public int Cur_Scale { get; set; }
        public string Cur_Name { get; set; }
        public decimal Cur_OfficialRate { get; set; }

        public override string ToString()
        {
            return $"{Date.ToString("dd-MM-yyyy")} : {Cur_Scale} {Cur_Abbreviation} = {Cur_OfficialRate} BYN";
        }
    }
}
