using UnityEngine;

namespace Codes.Scripts
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume;
        [Range(0.1f, 3f)]
        public float pitch;
        public bool loop;

        // use this to play the sound
        [HideInInspector]
        public AudioSource source;
    }
}