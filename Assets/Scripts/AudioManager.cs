using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource relaxMusic = null;
    [SerializeField] AudioSource eventsMusic = null;
    [SerializeField] AudioSource tensionMusic = null;
    [SerializeField] AudioSource mainMenuMusic = null;

    public static AudioManager manager = null;

    [SerializeField] int actualTension = 0;
    [SerializeField] int globalTension = 0;
    public int Tension
    {
        get
        {
            return globalTension;
        }

        set
        {
            if (value > 2 || value < 0)
            {
                return;
            }
            else
            {
                globalTension = value;
                float valueVolumen = 0;
                StopAllCoroutines();
                if (Tension < actualTension)
                {
                    if (Tension == 1)
                    {
                        valueVolumen = tensionMusic.volume;
                        StartCoroutine(FadeIn(valueVolumen, eventsMusic));
                        StartCoroutine(FadeOut(valueVolumen, tensionMusic));
                        if (relaxMusic.volume > 0)
                        {
                            StartCoroutine(FadeOut(relaxMusic.volume, tensionMusic));
                        }
                    }
                    else if (Tension == 0)
                    {
                        valueVolumen = eventsMusic.volume;
                        StartCoroutine(FadeIn(valueVolumen, relaxMusic));
                        StartCoroutine(FadeOut(valueVolumen, eventsMusic));
                        if (tensionMusic.volume > 0)
                        {
                            StartCoroutine(FadeOut(tensionMusic.volume, tensionMusic));
                        }
                    }
                }
                else if (Tension > actualTension)
                {
                    if (Tension == 1)
                    {
                        valueVolumen = relaxMusic.volume;
                        StartCoroutine(FadeIn(valueVolumen, eventsMusic));
                        StartCoroutine(FadeOut(valueVolumen, relaxMusic));
                        if (tensionMusic.volume > 0)
                        {
                            StartCoroutine(FadeOut(tensionMusic.volume, tensionMusic));
                        }
                    }
                    else if (Tension == 2)
                    {
                        valueVolumen = eventsMusic.volume;
                        StartCoroutine(FadeIn(valueVolumen, tensionMusic));
                        StartCoroutine(FadeOut(valueVolumen, eventsMusic));
                        if (relaxMusic.volume > 0)
                        {
                            StartCoroutine(FadeOut(relaxMusic.volume, tensionMusic));
                        }
                    }
                }
            }
        }

    }

    private void Awakes()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);

            relaxMusic.volume = 1;
            eventsMusic.volume = 0;
            tensionMusic.volume = 0;
            relaxMusic.Play();
            eventsMusic.Play();
            tensionMusic.Play();
            actualTension = Tension;

            /*if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                //mainmenu
            }
            else
            {
                //InGame
            }*/
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator FadeOut(float valueVolumen,AudioSource FadeOut)
    {
        Debug.Log("Out");
        while (valueVolumen > 0)
        {
            valueVolumen -= Time.deltaTime;
            FadeOut.volume = valueVolumen;
            yield return null;
        }
        actualTension = Tension;
    }

    IEnumerator FadeIn(float valueVolumen, AudioSource fadeIn)
    {
        float internalValue = 0;
        Debug.Log("In");
        while (internalValue < valueVolumen)
        {
            internalValue += Time.deltaTime;
            fadeIn.volume = internalValue / valueVolumen;
            yield return null;
        }
        actualTension = Tension;
    }
}
