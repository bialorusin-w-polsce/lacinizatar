using Lacinizatar.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace Lacinizatar.Bot
{
    internal class DefaultUpdateHandler : IUpdateHandler
    {
        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            if (message == null)
            {
                return;
            }

            var text = message.Text;
            if (text == null || text == string.Empty)
            {
                return;
            }

            if (text.Any(l => !ToBelLatin.belLetters.Contains(char.ToLowerInvariant(l)) && char.IsLetter(l)))
            {
                return;
            }

            await botClient.SendTextMessageAsync(message.Chat.Id, new ToBelLatin(text).Translate(), cancellationToken: cancellationToken);
        }
    }
}
