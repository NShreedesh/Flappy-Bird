using UnityEngine;

namespace Manager
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Source")]
        [SerializeField]
        private AudioSource sfxAudioSource;

        public void PlaySfxAudio(AudioClip clip)
        {
            sfxAudioSource.PlayOneShot(clip);
        }
    }
}
