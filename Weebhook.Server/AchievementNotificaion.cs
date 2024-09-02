namespace Api.Weebhook.Controllers
{
    public partial class AchievementsController
    {
        public class AchievementNotificaion
        {
            public string PlayerName { get; set; }
            public string AchievementName { get; set; }
            public DateTime UnlockedOn { get; set; }
        }
    }
}
