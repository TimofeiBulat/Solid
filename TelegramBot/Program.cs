using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.Interfaces;
using TelegramBot.Implementation;
using Telegram.Bot.Types.Enums;
using TelegramBot.Settings;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
        }

        static async Task Run()
        {                    
            var offset = 0;
            
            while (true)
            {
                var _bot = BotSettings._bot;

                var updates = await _bot.GetUpdatesAsync(offset);
              
                foreach(var update in updates)
                {
                    if(update.Message.Type == MessageType.TextMessage)
                    {
                        var commandType = GetCommandType(update.Message.Text, _bot);
                        var strategy = new Command(commandType);

                        strategy.Execute(update);
                    }                    

                    offset = update.Id + 1;
                }
            }
        }

        static ICommand GetCommandType(string message, ITelegramBotClient bot)
        {           
            var botCommand = BotSettings._botCommands.FirstOrDefault(x => message.StartsWith(x.CommandText,StringComparison.CurrentCultureIgnoreCase));

            return botCommand != null ? botCommand.Command : new DefaultCommand(bot);
        }   
    }
}
