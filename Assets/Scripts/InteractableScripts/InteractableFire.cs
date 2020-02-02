using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InteractableFire : InteractableBase
{
    [SerializeField] float secondsToClear = 0;
    [SerializeField] Slider temporizador;
    [SerializeField] ParticleSystem Rain;
    [SerializeField] ParticleSystem fire;
    [SerializeField] bool fuego = false;
    [SerializeField] AudioSource lluvia;
    [SerializeField] AudioSource extingir;

    bool alreadyCleared = false;

    private void OnEnable()
    {
        alreadyCleared = false;
        StartCoroutine(DelayToKill());
    }

    IEnumerator DelayToKill()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Subscribe to damage counter");
        if (fuego)
        {
            FindObjectOfType<GameController>().CountDisaster(GameVariables.Desatres.Incendios, true);
        }
        else
        {
            FindObjectOfType<GameController>().CountDisaster(GameVariables.Desatres.Pandemia, true);
        }
    }

    void Awake()
    {
        secondsToClear = Random.Range(2f, 10f);
        temporizador.value = 0;
        temporizador.maxValue = secondsToClear;
    }

    public override void OnStartInteraction()
    {
        StartCoroutine(SimpleCompleteEvent());
        lluvia.Play();
        extingir.Play();
    }

    IEnumerator SimpleCompleteEvent()
    {
        float value = temporizador.value;
        while (value < secondsToClear)
        {
            value += Time.deltaTime;
            temporizador.value = value;
            yield return null;
            Rain.Play();
        }
        fire.Stop();
        alreadyCleared = true;
        Debug.Log("Subscribe to damage counter");
        if (fuego)
        {
            FindObjectOfType<GameController>().CountDisaster(GameVariables.Desatres.Incendios, false);
        }
        else
        {
            FindObjectOfType<GameController>().CountDisaster(GameVariables.Desatres.Pandemia, false);
        }
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    public override void OnCancelInteraction()
    {
        if (alreadyCleared == false)
        {
            StopCoroutine(SimpleCompleteEvent());
        }
    }
}
