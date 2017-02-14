using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramBot.Interfaces
{
    public interface ICommand
    {
        Task ExecuteAsync(Update update);
    }
}
