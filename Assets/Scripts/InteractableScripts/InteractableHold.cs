using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InteractableHold : InteractableBase
{

    [SerializeField] float secondsToClear = 0;
    [SerializeField] Slider temporizador;

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
        }
        yield return null;
        gameObject.SetActive(false);
    }

    public override void OnCancelInteraction()
    {
        StopAllCoroutines();
    }

}
