using System;
using Manager;
using UnityEngine;

namespace Score
{
    public class ScoreController : MonoBehaviour
    {
        [Header("Score Values")]
        [SerializeField]
        private int score;

        [Header("Actions")]
        public static Action<int> OnScoreAdded;
        public static Action<int> OnHighScoreAdded;

        [Header("Audio")]
        [SerializeField]
        private AudioManager audioManager;
        [SerializeField]
        private AudioClip pointAudioClip;

        private void OnEnable()
        {
            GameManager.OnPlayerDead += SaveHighScore;
            GameManager.OnPlayerDead += InvokeAddScore;
        }

        private void OnDisable()
        {
            GameManager.OnPlayerDead -= SaveHighScore;
            GameManager.OnPlayerDead -= InvokeAddScore;
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if(GameManager.Instance.IsPlayerDead) return;
            
            if (col.gameObject.CompareTag(TagManager.PointTag))
            {
                AddScore();
            }
        }

        private void AddScore()
        {
            score += 1;
            audioManager.PlaySfxAudio(pointAudioClip);
            InvokeAddScore();
        }

        private void InvokeAddScore()
        {
            OnScoreAdded?.Invoke(score);
        }

        private void SaveHighScore()
        {
            if (PlayerPrefs.HasKey(TagManager.HighScore))
            {
                var highScore = PlayerPrefs.GetInt(TagManager.HighScore);
                OnHighScoreAdded?.Invoke(highScore);
                if (highScore >= score) return;
            }
            PlayerPrefs.SetInt(TagManager.HighScore, score);
            OnHighScoreAdded?.Invoke(score);
        }
    }
}