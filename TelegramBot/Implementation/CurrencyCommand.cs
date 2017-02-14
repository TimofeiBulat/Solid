using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Interfaces;
using TelegramBot.Services;
using TelegramBot.Models.CurrencyModel;
using System.Text.RegularExpressions;

namespace TelegramBot.Implementation
{
    public class CurrencyCommand:ICommand
    {
        private ITelegramBotClient _bot;

        public CurrencyCommand(ITelegramBotClient bot)
        {
            _bot = bot;
        }
        public async Task ExecuteAsync(Update update)
        {
            var messageParts = update.Message.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1);

            string currencyAbbreviation = null;
            DateTime date = DateTime.MinValue;

            if (messageParts.Count() > 0 && Regex.IsMatch(messageParts.ElementAt(0), "[A-Z]{3}", RegexOptions.IgnoreCase))
            {
                currencyAbbreviation = messageParts.ElementAt(0);

                if (messageParts.Count() > 1)
                {
                    DateTime.TryParse(messageParts.ElementAt(1), out date);
                }
            }

            var rate = new CurrencyServise().GetRate(currencyAbbreviation, date);

            await _bot.SendTextMessageAsync(update.Message.Chat.Id, rate.ToString());            
        }
    }
}
