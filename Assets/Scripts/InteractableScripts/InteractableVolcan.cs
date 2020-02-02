using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableVolcan : InteractableBase
{
    [SerializeField] float secondsToClear = 0;
    [SerializeField] Image temporizador;
    bool alreadyCleared = false;
    [SerializeField] bool nuke = false;
    
    private void OnEnable()
    {
        alreadyCleared = false;
        StartCoroutine(Emerge());
    }

    IEnumerator Emerge()
    {
        Vector3 actualPos = transform.localPosition;
        float value = 0;
        while(value <= 1)
        {
            value += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(Vector3.zero, actualPos, value);
            yield return null;
        }
        yield return new WaitForSeconds(3);
        Debug.Log("Subscribe to damage counter");
        if (nuke)
        {
            FindObjectOfType<GameController>().CountDisaster(GameVariables.Desatres.Radiacion, true);
        }
        else
        {
            FindObjectOfType<GameController>().CountDisaster(GameVariables.Desatres.Incendios, true);
        }
    }

    void Awake()
    {
        secondsToClear = Random.Range(1f, 3f);
        temporizador.fillAmount = 1f;
    }

    public override void OnStartInteraction()
    {
        Debug.Log("Start Interaction");
        StartCoroutine(SimpleCompleteEvent());
    }

    IEnumerator SimpleCompleteEvent()
    {
        float value = temporizador.fillAmount;
        
        while (value > 0f)
        {
            value -= Time.deltaTime / secondsToClear;
            temporizador.fillAmount =  value;
            yield return null;
        }
        alreadyCleared = true;
        if (nuke)
        {
            FindObjectOfType<GameController>().CountDisaster(GameVariables.Desatres.Radiacion, false);
        }
        else
        {
            FindObjectOfType<GameController>().CountDisaster(GameVariables.Desatres.Incendios, false);
        }
        StartCoroutine(Esconde());
    }

    IEnumerator Esconde()
    {
        Vector3 actualPos = transform.localPosition;
        float value = 0;
        while (value <= 1)
        {
            value += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(actualPos, Vector3.zero, value);
            yield return null;
        }
        if (nuke)
        {
            FindObjectOfType<GameController>().CountDisaster(GameVariables.Desatres.Radiacion, false);
        }
        else
        {
            FindObjectOfType<GameController>().CountDisaster(GameVariables.Desatres.Incendios, false);
        }
        gameObject.SetActive(false);
    }

    public override void OnCancelInteraction()
    {
        if (alreadyCleared == false)
        {
            StopAllCoroutines();
        }
    }
}
