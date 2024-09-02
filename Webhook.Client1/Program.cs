using System.Text.Json;
using System.Text;
using static Api.Weebhook.Controllers.AchievementsController;

namespace Webhook.Client1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            PostAchievementAsync().Wait();
        }
        static async Task PostAchievementAsync()
        {
            var httpClient = new HttpClient();

            var achievement = new AchievementNotificaion
            {
                PlayerName = "Fadi",
                AchievementName = "Unlock 1000 Achievements",
                UnlockedOn = DateTime.Now
            };
            var json = JsonSerializer.Serialize(achievement);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:7202/api/achievements/unlock-achievement";

            httpClient.DefaultRequestHeaders.Add("X-API-KEY", "MyTopSecretApiKey");

            var response = await httpClient.PostAsync(url, data);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Achievement unlocked successfully");
            }
            else
            {
                Console.WriteLine("Failed to unlock achievement");
            }

        }
    }
}
