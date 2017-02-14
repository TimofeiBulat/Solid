using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Interfaces;

namespace TelegramBot.Models
{
    public class BotCommand
    {
        public string CommandText { get; set; }
        public string Pattern { get; set; }
        public ICommand Command { get; set; }
    }
}
