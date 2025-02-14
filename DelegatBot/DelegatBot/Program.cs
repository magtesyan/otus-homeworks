using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;
using DelegatBot;
using dotenv.net;

static void Start(string message)
{
    Console.WriteLine($"Началась обработка сообщения {message}");
}

static void Complete(string message)
{
    Console.WriteLine($"Закончилась обработка сообщения {message}");
}

DotEnv.Load();
var token = DotEnv.Read()["TOKEN"];
var botClient = new TelegramBotClient("8120356962:AAFrMWFTn0bU8TRZSYtvZjPOvkahIjiE0c8");
var cancellationTokenSource = new CancellationTokenSource();

var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = [UpdateType.Message],
    DropPendingUpdates = true
};
var handler = new UpdateHandler();

handler.OnHandleUpdateStarted += Start;
handler.OnHandleUpdateCompleted += Complete;

botClient.StartReceiving(handler, receiverOptions);

var me = await botClient.GetMe();
Console.WriteLine($"{me.FirstName} запущен!");

Console.WriteLine("Нажмите клавишу A для выхода");
while (true)
{
    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
    Console.WriteLine(keyInfo.KeyChar);
    if (keyInfo.KeyChar == 'A')
    {
        try
        {
            if (handler != null)
            {
                handler.OnHandleUpdateStarted -= Start;
                handler.OnHandleUpdateCompleted -= Complete;
                cancellationTokenSource.Cancel();
            }
        }
        finally { handler = null; }
        break;
    } else
    {
        Console.WriteLine($"{me?.ToString()}");
    }
}
