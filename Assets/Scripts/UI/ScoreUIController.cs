using System;
using UI.Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScoreUIController : MonoBehaviour
    {
        [Header("Number Sprites")]
        [SerializeField]
        private ScoreUIData scoreUIData;
        
        [Header("Score Images")]
        [SerializeField]
        private Image image1;
        [SerializeField]
        private Image image2;
        [SerializeField]
        private Image image3;
        
        public void ChangeImageAccordingToScore(int score)
        {
            var scoreToString = score.ToString();
            
            switch (score)
            {
                case > 0 and < 10:
                    ChangeScoreImage(image3, Convert.ToInt32(scoreToString[0].ToString()));
                    break;
                case >= 10 and < 100:
                    ChangeScoreImage(image2, Convert.ToInt32(scoreToString[0].ToString()));
                    ChangeScoreImage(image3, Convert.ToInt32(scoreToString[1].ToString()));
                    break;
                case >= 100 and < 1000:
                    ChangeScoreImage(image1, Convert.ToInt32(scoreToString[0].ToString()));
                    ChangeScoreImage(image2, Convert.ToInt32(scoreToString[1].ToString()));
                    ChangeScoreImage(image3, Convert.ToInt32(scoreToString[2].ToString()));
                    break;
            }
        }

        private void ChangeScoreImage(Image image, int score)
        {
            image.sprite = scoreUIData.numberSprites[score];
        }
    }
}