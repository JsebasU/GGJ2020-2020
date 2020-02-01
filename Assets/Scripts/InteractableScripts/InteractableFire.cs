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

    void Awake()
    {
        secondsToClear = Random.Range(2f, 10f);
        temporizador.value = 0;
        temporizador.maxValue = secondsToClear;
    }

    public override void OnStartInteraction()
    {
        StartCoroutine(SimpleCompleteEvent());
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
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    public override void OnCancelInteraction()
    {
        StopAllCoroutines();
    }
}
