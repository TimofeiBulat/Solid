using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Interfaces;
using TelegramBot.Services;

namespace TelegramBot.Implementation
{
    class WeatherCommand : ICommand
    {
        private ITelegramBotClient _bot;

        public WeatherCommand(ITelegramBotClient bot)
        {
            _bot = bot;
        }

        public async Task ExecuteAsync(Update update)
        {
            var weather = "Unknown city";
            var city = update.Message.Text.Split(new char[] {' '}, 2, StringSplitOptions.RemoveEmptyEntries).Skip(1).FirstOrDefault();

            if (string.IsNullOrEmpty(city))
                city = "Minsk";           

            if(Regex.IsMatch(city,"[A-ZА-Я-]", RegexOptions.IgnoreCase))
            {
                var weatherResponce = new WeatherService().GetWeatherForCity(city);
                weather = weatherResponce;
            }             

            await _bot.SendTextMessageAsync(update.Message.Chat.Id, weather);
        }
    }
}
