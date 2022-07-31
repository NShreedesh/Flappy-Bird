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
                if (_instance == null)
                {
                    Debug.Log("Null GameManager Found...");
                }
                return _instance;
            }
        }

        [field: Header("Game Values")]
        [field:SerializeField]
        public bool IsPlayerDead { get; private set; }

        private void Awake()
        {
            _instance = this;
        }

        public void PlayerDead()
        {
            IsPlayerDead = true;
            Invoke(nameof(ResetGame), 2f);
        }

        public void ResetGame()
        {
            SceneManager.LoadScene(0);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }
    }
}