using api.Dtos.Leaderboard;
using api.Models;

namespace api.Mapper
{
    public static class Leaderboardmapper
    {
        public static LeaderboardDTO ToLeaderboardDTO(this QuizHistory historymodel)
        {
            return new LeaderboardDTO{
                Username = historymodel.user.UserFirstName,
                Score = historymodel.Score,
                TimeTakenSeconds = historymodel.TimeTakenSeconds
            };
        }
    }
}