using UnityEngine;

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

        public void SetPlayerDead()
        {
            IsPlayerDead = true;
        }
    }
}