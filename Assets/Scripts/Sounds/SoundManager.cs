using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance { get { return instance; } }

    [SerializeField] private SoundType[] Sounds;

    [SerializeField] private AudioSource effect;
    [SerializeField] private AudioSource music;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void Play (Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);

        if (clip != null)
        {
            effect.PlayOneShot(clip);
        }
    }

    public void PlayBackgroundMusic (Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            music.clip = clip;
            music.Play();
        }
    }

    public void StopMusic()
    {
        music.Stop();
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundType == sound);

        if (item != null)
        {
            return item.clip;
        }

        return null;
    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip clip;
}

public enum Sounds
{
    ButtonClick,
    PlayerHit,
    BackgroundMusic,
    GameplayMusic,
    DeathMusic,
    Pickup,
    EndLevel,
    FinishMusic
}
