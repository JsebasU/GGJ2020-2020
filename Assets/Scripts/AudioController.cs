using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioSource[] _audioSources;
    public AudioSource fxAudioSource;
    public AudioMixerGroup EasyMix;
    public AudioMixerGroup MidMix;
    public AudioMixerGroup HardMix;
    public AudioMixerGroup FX;

    public AudioClip startClip; 
    public AudioClip easyClip;
    public AudioClip midClip;
    public AudioClip hardClip;

    private Coroutine fadeAudio;
    private int audioState = -1;

    private void Start()
    {
        foreach (AudioSource source in _audioSources)
        {
            source.Play();
        }
        fxAudioSource.clip = startClip;
        fxAudioSource.Play();
        this.audioState = -1;
    }

    public void SetNewTension(float tension)
    {
        if (tension > .75f && audioState != 0)
        {
            this.audioState = 0;
            if (fadeAudio != null)
                StopCoroutine(fadeAudio);
            this.fadeAudio = StartCoroutine(FadeInOut(0, GameVariables.MusicFadeTime));
        }
        else if (tension < .75f && tension > .25f && audioState != 1)
        {
            this.audioState = 1;
            if (fadeAudio != null)
                StopCoroutine(fadeAudio);
            this.fadeAudio = StartCoroutine(FadeInOut(1, GameVariables.MusicFadeTime));
        }
        else if(tension <.25f && audioState != 2)
        {
            this.audioState = 2;
            if (fadeAudio != null)
                StopCoroutine(fadeAudio);
            this.fadeAudio = StartCoroutine(FadeInOut(2, GameVariables.MusicFadeTime));
        }
        if(this.audioState != 1)
            fxAudioSource.Stop();
    }

    public IEnumerator FadeInOut(int fadeSource , float FadeTime)
    { 
        while (_audioSources[fadeSource].volume < 1f)
        {
            _audioSources[0].volume += (0 == fadeSource ? 1 : -1) * Time.deltaTime / FadeTime;
            _audioSources[1].volume += (1 == fadeSource ? 1 : -1) * Time.deltaTime / FadeTime;
            _audioSources[2].volume += (2 == fadeSource ? 1 : -1) * Time.deltaTime / FadeTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
