using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioSource[] _audioSources;
    public AudioMixerGroup EasyMix;
    public AudioMixerGroup MidMix;
    public AudioMixerGroup HardMix;

    public AudioClip easyClip;
    public AudioClip midClip;
    public AudioClip hardClip;

    public Vector2 easyRange;
    public Vector2 midRange;
    public Vector2 hardRange;

    private Coroutine fadeAudio;
    
    private void Start()
    {
        foreach (AudioSource source in _audioSources)
        {
            source.Play();
        }
    }

    public void SetNewTension(float tension)
    {
        /*
        this._audioSources[0].volume = Mathf.Clamp((tension - easyRange.x) / easyRange.y, 0f, 1f);
        this._audioSources[1].volume = Mathf.Clamp((tension - midRange.x) / midRange.y, 0f, 1f);
        this._audioSources[2].volume = Mathf.Clamp((tension - hardRange.x) / hardRange.y, 0f, 1f);
        */
    }
}
