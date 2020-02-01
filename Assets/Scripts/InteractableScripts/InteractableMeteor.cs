using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InteractableMeteor : InteractableBase
{
    [SerializeField] float secondsToClear = 0;
    [SerializeField] Slider temporizador;
    [SerializeField] Meteoro meteoro;
    bool alreadyCleared = false;

    private void OnEnable()
    {
        alreadyCleared = false;
    }

    void Awake()
    {
        secondsToClear = Random.Range(2f, 10f);
        temporizador.value = 0;
        temporizador.maxValue = secondsToClear;
    }

    public override void OnStartInteraction()
    {
        meteoro.velocity = 0;
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
        meteoro.velocity = -5;
        alreadyCleared = true;
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    public override void OnCancelInteraction()
    {
        if(alreadyCleared == false)
        {
            meteoro.velocity = 2;
            StopAllCoroutines();
        }
    }
}
