using Manager;
using UnityEngine;

namespace Player
{
    public class PlayerDeath : MonoBehaviour
    {
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag(TagManager.GroundTag) ||
                col.gameObject.CompareTag(TagManager.ObstacleTag))
            {
                print("eh");
                Die();
            }
        }

        private static void Die()
        {
            GameManager.Instance.SetPlayerDead();
        }
    }
}
