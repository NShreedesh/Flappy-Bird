using Manager;
using UnityEngine;

namespace Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [Header("Manager Info")]
        [SerializeField]
        private GameManager gameManager;
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag(TagManager.GroundTag))
            {
                Die();
            }
        }

        private void Die()
        {
            gameManager.SetPlayerDead();
        }
    }
}
