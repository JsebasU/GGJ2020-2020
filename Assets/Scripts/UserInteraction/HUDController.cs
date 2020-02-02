using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Image populationSlider;
    public Text populationCounter;
    
    private GameController _gameController;

    public void SetGameController(GameController controller)
    {
        this._gameController = controller;
    }

    public void SetPopulationScale(float actualPop, float maxPop)
    {
        populationCounter.text = actualPop.ToString();
        populationSlider.fillAmount = actualPop / maxPop;
    }
}
