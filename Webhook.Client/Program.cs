using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using static Api.Weebhook.Controllers.AchievementsController;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
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
    if(response.IsSuccessStatusCode)
    {
        Console.WriteLine("Achievement unlocked successfully");
    }
    else
    {
        Console.WriteLine("Failed to unlock achievement");
    }
    
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
