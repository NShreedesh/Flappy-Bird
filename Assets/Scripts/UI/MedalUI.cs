using Score;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MedalUI : MonoBehaviour
    {
        [Header("Medal Sprite")]
        [SerializeField]
        private Image medalImage;
        
        [Header("Medal Images")]
        [SerializeField]
        private Sprite[] medalSprites;
        
        private void OnEnable()
        {
            ScoreController.OnScoreAdded += ChangeMedalImage;
        }
        
        private void OnDisable()
        {
            ScoreController.OnScoreAdded -= ChangeMedalImage;
        }
        
        private void ChangeMedalImage(int score)
        {
            medalImage.sprite = score switch
            {
                >= 0 and < 10 => medalSprites[0],
                >= 10 and < 20 => medalSprites[1],
                _ => medalSprites[2]
            };
        }
    }
}
