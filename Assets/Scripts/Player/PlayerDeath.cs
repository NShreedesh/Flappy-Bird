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
        private AudioClip hitClip;
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (GameManager.Instance.IsPlayerDead) return;
            
            if (col.gameObject.CompareTag(TagManager.GroundTag) ||
                col.gameObject.CompareTag(TagManager.ObstacleTag))
            {
                Die();
            }
        }

        private void Die()
        {
            audioManager.PlaySfxAudio(hitClip);
            GameManager.Instance.PlayerDead();
        }
    }
}
