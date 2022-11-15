using System;
using UnityEngine;

namespace Codes.Scripts
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;

        private static AudioManager instance;
        
        // Awake is called before Start
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            
            DontDestroyOnLoad(gameObject);
            
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }

        void Start()
        {
            Play("Theme");
        }

        public void Play(string soundName)
        {
            Sound s = Array.Find(sounds, sound => sound.name == soundName);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + soundName + " not found!");
                return;
            }
            s.source.Play();
        }
    }
}

// Code to play sound
// FindObjectOfType<AudioManager>().Play("name of sound");

