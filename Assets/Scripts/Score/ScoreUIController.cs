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
        
        public void ChangeImageAccordingToScore(int score)
        {
            var scoreToString = score.ToString();
            
            switch (score)
            {
                case > 0 and < 10:
                    ChangeImage(image3, Convert.ToInt32(scoreToString[0].ToString()));
                    break;
                case >= 10 and < 100:
                    ChangeImage(image2, Convert.ToInt32(scoreToString[0].ToString()));
                    ChangeImage(image3, Convert.ToInt32(scoreToString[1].ToString()));
                    break;
                case >= 100 and < 1000:
                    ChangeImage(image1, Convert.ToInt32(scoreToString[0].ToString()));
                    ChangeImage(image2, Convert.ToInt32(scoreToString[1].ToString()));
                    ChangeImage(image3, Convert.ToInt32(scoreToString[2].ToString()));
                    break;
            }
        }

        private void ChangeImage(Image image, int score)
        {
            image.sprite = numberSprites[score];
        }
    }
}