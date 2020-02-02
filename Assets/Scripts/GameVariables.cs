using System.Collections;
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
    public static List<int> DesastresMultp = new List<int> {1,1,1,1,1};
    public enum GameState {Menu, Game, Win, Lose, Halt};
    
    public static float minTimeEvent = 5;
    public static float maxTimeEvent = 10;

    public static int PopulationIncrem = 10;
    public static int InitialPopulation = 10;
    
    public static Quaternion CameraInitialPosition = Quaternion.identity;
    public static float CameraInitialScale = 2f;
}
