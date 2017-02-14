using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.Implementation;
using TelegramBot.Models;

namespace TelegramBot.Settings
{
    public static class BotSettings
    {
        public static readonly ITelegramBotClient _bot;

        public static readonly List<BotCommand> _botCommands;

        public static readonly string _weatherServiceUrl;
        public static readonly string _weatherApiKey;

        public static readonly string _currencyServiceUrl;
        static BotSettings()
        {
            var botToken = ConfigurationManager.AppSettings["BotToken"];
            _bot = new TelegramBotClient(botToken);

            _botCommands = new List<BotCommand>();
            _botCommands.Add(new BotCommand { CommandText = "/weather", Command = new WeatherCommand(_bot), Pattern = "/weather city" });
            _botCommands.Add(new BotCommand { CommandText = "/currency", Command = new CurrencyCommand(_bot), Pattern = "/currency [abbreviation] [date]" });
            _botCommands.Add(new BotCommand { CommandText = "/help", Command = new DefaultCommand(_bot), Pattern = "/help" });

            _weatherServiceUrl = ConfigurationManager.AppSettings["WeatherServiceUrl"];
            _weatherApiKey = ConfigurationManager.AppSettings["WeatherApiKey"];

            _currencyServiceUrl = ConfigurationManager.AppSettings["CurrencyServiceUrl"];
        }

        public static string GetBotCommands()
        {
            return string.Join("\r\n", _botCommands.Select(x => x.Pattern).ToList());
        }
    }
}
