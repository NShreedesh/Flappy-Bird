using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public bool IsPlayerDead { get; private set; }

        public void SetPlayerDead()
        {
            IsPlayerDead = true;
        }

        public void ResetGame()
        {
            IsPlayerDead = false;
        }
    }
}