using LootLocker.Requests;
using UnityEngine;

namespace Leaderboard
{
    public class LeaderboardController : MonoBehaviour
    {
        private const int LeaderboardId = 5120;
        private string _memberId;
        
        private void Start()
        { 
            LootLockerSDKManager.StartGuestSession(SystemInfo.deviceUniqueIdentifier,(response) =>
            {
                if (!response.success) return;
                _memberId = response.player_id.ToString();
            });
        }

        private void SubmitScore(int score)
        {
            LootLockerSDKManager.SubmitScore(_memberId, score, LeaderboardId, response =>
            {
                if (response.success)
                {
                    
                }
                else
                {
                    
                }
            });
        }

        private void GetLeaderboard()
        {
            LootLockerSDKManager.GetScoreList(LeaderboardId, 10, 0, response =>
            {
                if (response.success)
                {
                    foreach (var item in response.items)
                    {
                        print(item.member_id + " " + item.score);
                    }
                }
                else
                {
                    
                }
            });
        }
    }
}
