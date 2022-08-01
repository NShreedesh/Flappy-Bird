using Score;
using UnityEngine;

namespace UI
{
    public class HighScoreUI : MonoBehaviour
    {
        [SerializeField]
        private ScoreUIController scoreUIController;

        private void OnEnable()
        {
            ScoreController.OnHighScoreAdded += OnHighScoreChange;
        }
        
        private void OnDisable()
        {
            ScoreController.OnHighScoreAdded -= OnHighScoreChange;
        }
        
        private void OnHighScoreChange(int highScore)
        {
            scoreUIController.ChangeImageAccordingToScore(highScore);
        }

    }
}