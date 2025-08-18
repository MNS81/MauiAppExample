using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppExample.Components.Services
{
    public class Telegram
    {
        private static readonly string BotToken = "7558691763:AAEz4-PBKomouwhR0YVrG0czxz_49Iolio0";
        private static readonly string ChatId = "-1002263508906";
        private static readonly HttpClient Client = new HttpClient();

        public static async Task SendMessageAsync(string message)
        {
            string url = $"https://api.telegram.org/bot{BotToken}/sendMessage";
            var payload = new { chat_id = ChatId, text = message };
            var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
    }
}
