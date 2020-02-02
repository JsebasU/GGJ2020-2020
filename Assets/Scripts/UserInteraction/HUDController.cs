using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Transform populationSlider;
    public Text populationCounter;
    
    private GameController _gameController;

    public void SetGameController(GameController controller)
    {
        this._gameController = controller;
    }

    public void SetPopulationScale(float actualPop, float maxPop)
    {
        populationCounter.text = actualPop.ToString();
        populationSlider.localScale = new Vector3(actualPop / maxPop, 1f, 1f);
    }
}
