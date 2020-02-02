using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Image populationSlider;
    public Text populationCounter;
    public TMP_InputField playerName;
    
    // UI menu
    public GameObject menuView;
    
    // UI Game
    public GameObject HUDView;

    private GameController _gameController;

    public void SetMenuView(bool setActive = false)
    {
        this.menuView.SetActive(setActive);
    }

    public void SetHUDView(bool setActive = false)
    {
        this.HUDView.SetActive(setActive);
    }
    
    public void SetGameController(GameController controller)
    {
        this._gameController = controller;
    }

    public void SetPopulationScale(float actualPop, float maxPop)
    {
        populationCounter.text = actualPop.ToString();
        populationSlider.fillAmount = actualPop / maxPop;
    }

    public void SetTimer(float time)
    {
        
    }
}
