using Objects;
using UnityEngine;

namespace Managers
{
    public class AudioManager : Singelton<AudioManager>
    {
        
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioClip[] audioClips;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        public void PlaySound(int index)
        {
            sfxSource.PlayOneShot(audioClips[index]);
        }
    }
}
