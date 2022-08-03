using UnityEditor;
using UnityEngine;

namespace UI.Data
{
    [CreateAssetMenu(fileName = "ScoreData", menuName = "ScriptableObjects/Score Data", order = 1)]
    public class ScoreUIData : ScriptableObject
    {
        [Header("Number Sprites")]
        public Sprite[] numberSprites;
    }
}
