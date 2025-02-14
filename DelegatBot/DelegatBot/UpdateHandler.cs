using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Net.Http.Json;
using System.Threading;

namespace DelegatBot
{
    public class UpdateHandler : IUpdateHandler
    {
        public delegate void MessageHandler(string message);
        public event MessageHandler? OnHandleUpdateStarted;
        public event MessageHandler? OnHandleUpdateCompleted;
        public record CatFactDto(string fact, int length);
        public Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && update.Message != null)
            {
                var message = update.Message;
                OnHandleUpdateStarted?.Invoke(message.Text ?? "");

                if (message.Text != null && message.Text.StartsWith('/'))
                {
                    switch (message.Text.Split(' ')[0])
                    {
                        case "/cat":
                            var fact = GetRandomFact().Result;
                            return SendMessage(client, message.Chat.Id, fact);
                    }
                }
                else
                {
                    OnHandleUpdateCompleted?.Invoke(message.Text ?? "");
                    return SendMessage(client, message.Chat.Id, $"Сообщение успешно принято");
                }
            }

            return Task.CompletedTask;
        }

        private static async Task SendMessage(ITelegramBotClient client, long chatId, string text)
        {
            await client.SendMessage(chatId, text);
        }

        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private static async Task<string> GetRandomFact()
        {
            var cts = new CancellationTokenSource();
            using var client = new HttpClient();
            var catFact = await client.GetFromJsonAsync<CatFactDto>("https://catfact.ninja/fact", cts.Token);
            return catFact?.fact ?? "";
        }
    }
}
