using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBot.Interfaces;

namespace TelegramBot.Implementation
{
    public class Command
    {
        private ICommand _command;

        public Command(ICommand command)
        {
            _command = command;
        }
        public void Execute(Update update)
        {
            _command.ExecuteAsync(update);
        }
    }
}
