using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int[] disasterCount;
    private GameVariables.GameState gameState = GameVariables.GameState.Menu;

    private void Start()
    {
        this.disasterCount = new int[GameVariables.Desatres.GetNames(typeof(GameVariables.Desatres)).Length];
    }

    public void CountDisaster(GameVariables.Desatres desastre, bool incrementa = false)
    {
        this.disasterCount[(int) desastre] += incrementa? 1 : -1;
    }

    public void StartGame()
    {
        StartCoroutine(StartGameAnimation());
    }

    private IEnumerator StartGameAnimation()
    {
        yield break;
    }

    public void Menu(bool pause = false)
    {
        
    }

    public void WinLose(bool lose = false)
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    private void Update()
    {
        switch (gameState)
        {
            case GameVariables.GameState.Menu:
                break;
            case GameVariables.GameState.Game:
                break;
        }
    }
}
