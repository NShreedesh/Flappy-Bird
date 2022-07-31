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
            OnScoreAdded?.Invoke(score);
        }
    }
}