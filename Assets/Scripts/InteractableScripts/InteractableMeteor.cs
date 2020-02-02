using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InteractableMeteor : InteractableBase
{
    [SerializeField] float secondsToClear = 0;
    [SerializeField] Image temporizador;
    [SerializeField] Meteoro meteoro;
    
    bool alreadyCleared = false;

    private void OnEnable()
    {
        alreadyCleared = false;
    }

    void Awake()
    {
        secondsToClear = Random.Range(1f, 3f);
        temporizador.fillAmount = 0;
    }

    public override void OnStartInteraction()
    {
        meteoro.velocity = 0;
        StartCoroutine(SimpleCompleteEvent());
        
    }

    IEnumerator SimpleCompleteEvent()
    {
        float value = temporizador.fillAmount;
        while (value < secondsToClear)
        {
            value += Time.deltaTime / secondsToClear;
            temporizador.fillAmount = value;
            yield return null;
        }
        meteoro.velocity = -0.5f;
        alreadyCleared = true;
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    public override void OnCancelInteraction()
    {
        if(alreadyCleared == false)
        {
            meteoro.velocity = 0.01f;
            StopAllCoroutines();
        }
    }
}
