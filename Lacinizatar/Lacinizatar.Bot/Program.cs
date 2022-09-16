// See https://aka.ms/new-console-template for more information
using Lacinizatar.Bot;
using Lacinizatar.Logic;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using var cts = new CancellationTokenSource();
var bot = new TelegramBotClient("5657259321:AAEOK2pfS6OaKJeb5xa5wW430fak-arSvYo");
bot.StartReceiving(new Lacinizatar.Bot.DefaultUpdateHandler(), new ReceiverOptions() { AllowedUpdates = Array.Empty<UpdateType>() });
Console.ReadLine();
cts.Cancel();