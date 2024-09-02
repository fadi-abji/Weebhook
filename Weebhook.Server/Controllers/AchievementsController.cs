using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Api.Weebhook.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
    public partial class AchievementsController : ControllerBase
    {
        private const string ApiKey = "MyTopSecretApiKey";

        [HttpPost("unlock-achievement")]
        public IActionResult UnlockAchievement(AchievementNotificaion notification, [FromHeader(Name ="X-API-KEY")] string apiKey)
        {
            if (apiKey != ApiKey)
            {
                return Unauthorized("Invalid Api Key");
            }
            Console.WriteLine($"player {notification.PlayerName} unlocked: {notification.AchievementName} on {notification.UnlockedOn}.");
            return Ok();
        }
    }
}
