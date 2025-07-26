using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private List<AudioSource> playingSources = new List<AudioSource>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayExclusive(AudioSource source)
    {
        StopAllExcept(source);
        if (!source.isPlaying)
        {
            source.Play();
            playingSources.Add(source);
        }
    }

    public void StopAllExcept(AudioSource except)
    {
        foreach (var src in playingSources)
        {
            if (src != null && src != except && src.isPlaying)
            {
                src.Stop();
            }
        }
        playingSources.RemoveAll(src => src == null || src == except);
    }

    public void StopAll()
    {
        foreach (var src in playingSources)
        {
            if (src != null && src.isPlaying)
            {
                src.Stop();
            }
        }
        playingSources.Clear();
    }
}
