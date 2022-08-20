using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance.Equals(null))
                {
                    Debug.Log("Null GameManager Found...");
                }
                return _instance;
            }
        }

        [field: Header("Game Values")]
        [field:SerializeField]
        public bool IsPlayerDead { get; private set; }

        [Header("Actions")]
        public static Action OnPlayerDead;

        private void Awake()
        {
            _instance = this;
        }

        public void PlayerDead()
        {
            IsPlayerDead = true;
            OnPlayerDead?.Invoke();
        }

        public static void ResetGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}