using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableVolcan : InteractableBase
{
    [SerializeField] float secondsToClear = 0;
    [SerializeField] Slider temporizador;
    bool alreadyCleared = false;
    [SerializeField] bool nuke = false;

    private void OnEnable()
    {
        alreadyCleared = false;
        StartCoroutine(Emerge());
    }

    IEnumerator Emerge()
    {
        Vector3 actualPos = transform.position;
        float value = 0;
        while(value <= 1)
        {
            value += Time.deltaTime;
            transform.position = new Vector3(actualPos.x - 2 + (value * 2), actualPos.y - 2 + (value * 2), actualPos.z - 2 + (value * 2));
            yield return null;
        }
        yield return new WaitForSeconds(3);
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
        Debug.Log("");
        Vector3 actualPos = transform.position;
        float value = 0;
        while (value <= 1)
        {
            value += Time.deltaTime;
            transform.position = new Vector3(actualPos.x - (value * 2), actualPos.y - (value * 2), actualPos.z - (value * 2));
            yield return null;
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
