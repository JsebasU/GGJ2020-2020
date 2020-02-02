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
        Debug.Log("Tension " + tension);
        if ((tension > .75f || tension == 0f) && _audioSources[0].volume == 0)
        {
            if(fadeAudio != null)
                StopCoroutine(fadeAudio);
            fadeAudio = StartCoroutine(FadeSource(0));
        }
        else if(tension > .25f  && _audioSources[1].volume == 0)
        {
            if(fadeAudio != null)
                StopCoroutine(fadeAudio);
            fadeAudio = StartCoroutine(FadeSource(1));
        }
        else if (_audioSources[2].volume == 0)
        {
            if(fadeAudio != null)
                StopCoroutine(fadeAudio);
            fadeAudio = StartCoroutine(FadeSource(2));
        }
    }

    private IEnumerator FadeSource(int source)
    {
        float volume = 0;
        while (_audioSources[source].volume != 1)
        {
            for (int i = 0; i < _audioSources.Length; i++)
            {
                _audioSources[i].volume = Mathf.Clamp(_audioSources[i].volume += Time.deltaTime * (i == source ? 1 : -1), 0f, 1f);
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
