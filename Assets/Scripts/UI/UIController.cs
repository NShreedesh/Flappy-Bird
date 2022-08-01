using Manager;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [Header("UI Info")]
        [SerializeField]
        private GameObject menuPanel;
        [SerializeField]
        private GameObject scorePanel;
        
        private void OnEnable()
        {
            GameManager.OnPlayerDead += OnPlayerDeath;
        }

        private void OnDisable()
        {
            GameManager.OnPlayerDead -= OnPlayerDeath;
        }

        private void OnPlayerDeath()
        {
            menuPanel.SetActive(true);
            scorePanel.SetActive(false);
        }

        public void OnOkButtonPressed()
        {
            GameManager.ResetGame();
        }
    }
}
