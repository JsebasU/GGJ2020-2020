﻿using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameVariables
{
    public static string VOLCAN_PREFAB = "Prefabs/Volcan";
    public static string METEORITO_PREFAB = "Prefabs/Meteoros";
    public static string RADIACION_PREFAB = "Prefabs/Radiacion";
    public static string INCENDIO_PREFAB = "Prefabs/Incendios";
    public static string PANDEMIA_PREFAB = "Prefabs/Pandemia";
    public static string CASA_PREFAB = "Prefabs/Casa";

    public enum Desatres { Meteorito, Volcan, Radiacion, Pandemia, Incendios};
    public static List<int> DesastresMultp = new List<int> {1,2,2,2,3};
    public enum GameState {Menu, Game, Win, Lose, Halt};
    
    public static float minTimeEvent = 5;
    public static float maxTimeEvent = 10;
    public static float gameTime = 120;

    public static float minEventValue = 1f;
    
    public static int PopulationIncrem = 10;
    public static int InitialPopulation = 1000;
    
    public static Quaternion CameraInitialPosition = Quaternion.identity;
    public static float CameraInitialScale = 2f;

    public static float WorldRadius = 5f;
    
    public static int seed = 0;
    public static int poblacion = 0;

    public static float MoonSpeed = 10f;
    public static float CowSpeed = 10f;
    public static float UfoSpeed = 10f;

    public static float CameraSensitivity = 2;

    public static float MusicFadeTime = 1f;
}
