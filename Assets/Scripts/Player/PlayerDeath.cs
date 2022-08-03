using Manager;
using UnityEngine;

namespace Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [Header("Audio")]
        [SerializeField]
        private AudioManager audioManager;
        [SerializeField]
        private AudioClip collisionClip;
        [SerializeField]
        private AudioClip deathClip;
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag(TagManager.GroundTag))
            {
                audioManager.PlaySfxAudio(deathClip);
                Die();
            }
            else if (col.gameObject.CompareTag(TagManager.ObstacleTag))
            {
                audioManager.PlaySfxAudio(collisionClip);
                Die();
            }
        }

        private static void Die()
        {
            GameManager.Instance.PlayerDead();
        }
    }
}
