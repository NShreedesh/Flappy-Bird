using System;
using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class ScoreUIController : MonoBehaviour
    {
        [Header("Number Sprites")]
        [SerializeField]
        private Sprite[] numberSprites;

        [Header("Score Images")]
        [SerializeField]
        private Image image1;
        [SerializeField]
        private Image image2;
        [SerializeField]
        private Image image3;

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
            ChangeImageAccordingToScore(score);
        }

        private void ChangeImageAccordingToScore(int score)
        {
            switch (score)
            {
                case > 0 and < 10:
                    image3.sprite = numberSprites[score];
                    break;
                case >= 10 and < 100:
                    image2.sprite = numberSprites[Convert.ToInt32(score.ToString()[0].ToString())];
                    image3.sprite = numberSprites[Convert.ToInt32(score.ToString()[1].ToString())];
                    break;
                case >= 100 and < 1000:
                    image1.sprite = numberSprites[Convert.ToInt32(score.ToString()[0].ToString())];
                    image2.sprite = numberSprites[Convert.ToInt32(score.ToString()[1].ToString())];
                    image3.sprite = numberSprites[Convert.ToInt32(score.ToString()[2].ToString())];
                    break;
            }
        }
    }
}