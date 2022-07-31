using Score;
using UnityEngine;

namespace UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField]
        private ScoreUIController scoreUIController;
        
        private void OnEnable()
        {
            ScoreController.OnScoreAdded += OnScoreChange;
        }
        
        private void OnDisable()
        {
            ScoreController.OnScoreAdded -= OnScoreChange;
        }
        
        private void OnScoreChange(int score)
        {
            scoreUIController.ChangeImageAccordingToScore(score);
        }
    }
}