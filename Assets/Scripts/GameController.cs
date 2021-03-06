﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Dependencias
    public Spawn Spawn;
    public HUDController HudController;
    public CameraController CameraController;
    public WorldScript WorldScript;
    public AudioController AudioController;
    
    private int[] disasterCount;
    [HideInInspector] public GameVariables.GameState gameState = GameVariables.GameState.Menu;
    
    [HideInInspector] public float actualPopulation = 0f;
    private float maxPopulation = 0f;
    private float gameTime;

    private bool pause = true;
    
    public GameVariables.GameState GetGameState()
    {
        return this.gameState;
    }
    
    private void Start()
    {
        if (this.Spawn == null)
            this.Spawn = FindObjectOfType<Spawn>();
        if (this.HudController == null)
            this.HudController = FindObjectOfType<HUDController>();
        if (this.CameraController == null)
            this.CameraController = FindObjectOfType<CameraController>();
        if (this.WorldScript == null)
            this.WorldScript = FindObjectOfType<WorldScript>();
        if (this.AudioController == null)
            this.AudioController = FindObjectOfType<AudioController>();
        this.disasterCount = new int[GameVariables.Desatres.GetNames(typeof(GameVariables.Desatres)).Length];
        this.HudController.SetGameController(this);
        this.CameraController.SetGameController(this);
    }

    public void CountDisaster(GameVariables.Desatres desastre, bool incrementa = false)
    {
        this.disasterCount[(int) desastre] += incrementa? 1 : -1;
        this.disasterCount[(int) desastre] = Mathf.Max(this.disasterCount[(int) desastre], 0);
    }

    public void StartGame()
    {
        if(gameState == GameVariables.GameState.Game)
            return;
        this.actualPopulation = GameVariables.InitialPopulation;
        this.maxPopulation = GameVariables.InitialPopulation;
        this.WorldScript.changeSeed(this.HudController.playerName.text);
        StartCoroutine(StartGameAnimation());
    }

    private IEnumerator StartGameAnimation()
    {
        this.gameTime = GameVariables.gameTime;
        this.HudController.SetTimer(this.gameTime);
        Transform CameraAxis = this.CameraController.GetCameraAxis();
        Quaternion initialRotation = CameraAxis.localRotation;
        float initialSize = Camera.main.orthographicSize;
        for (float timer = 0; timer < 1;)
        {
            timer += Time.deltaTime;
            Camera.main.orthographicSize = Mathf.Lerp(initialSize, GameVariables.CameraInitialScale, timer);
            CameraAxis.localRotation = Quaternion.Lerp(initialRotation, GameVariables.CameraInitialPosition, timer);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        gameState = GameVariables.GameState.Game;
    }

    public void Menu()
    {
        pause = !pause;
        if (pause)
        {
            Time.timeScale = 0;
            this.HudController.SetMenuView(true);
            this.HudController.SetHUDView(false);
        }
        else
        {
            Time.timeScale = 1;
            this.HudController.SetHUDView(true);
            this.HudController.SetMenuView(false);
        }
        
    }

    public void WinLose(bool lose = false)
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    private void FixedUpdate()
    {
        switch (gameState)
        {
            case GameVariables.GameState.Menu:
                break;
            case GameVariables.GameState.Game:
                if (!this.Spawn.IsActive)
                    this.Spawn.IsActive = true;
                this.actualPopulation += GameVariables.PopulationIncrem;
                for (int i = 0; i < disasterCount.Length; i++)
                {
                    this.actualPopulation -= disasterCount[i] * GameVariables.DesastresMultp[i];
                    Debug.Log($"Damage: " + disasterCount[i].ToString());
                }
                this.AudioController.SetNewTension(this.actualPopulation / this.maxPopulation);
                this.gameTime -= Time.deltaTime;
                this.HudController.SetTimer(this.gameTime);
                this.maxPopulation = Mathf.Max(this.actualPopulation, this.maxPopulation);
                HudController.SetPopulationScale(this.actualPopulation,this.maxPopulation);
                if (this.actualPopulation <= 0)
                {
                    gameState = GameVariables.GameState.Lose;
                }
                break;
            case GameVariables.GameState.Lose:
                //Menu();
                if(!HudController.gameOver.activeSelf)
                HudController.gameOver.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
    public void KillPopulation(int killedPopulation)
    {
        this.actualPopulation -= killedPopulation;
        this.actualPopulation = Mathf.Max(this.actualPopulation, 0);
    }
}
