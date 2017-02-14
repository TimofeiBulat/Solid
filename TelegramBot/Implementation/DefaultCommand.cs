using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Interfaces;
using TelegramBot.Settings;

namespace TelegramBot.Implementation
{
    class DefaultCommand : ICommand
    {
        private ITelegramBotClient _bot;
        public DefaultCommand(ITelegramBotClient bot)
        {
            _bot = bot;
        }
        public async Task ExecuteAsync(Update update)
        {
            var allCommands = BotSettings.GetBotCommands();

            await _bot.SendTextMessageAsync(update.Message.Chat.Id, allCommands);
        }
    }
}
