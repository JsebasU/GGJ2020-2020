using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager manager = null;
    public Texture2D worldMaterial;
    public string playerName = "";
    public int poblacion = 0;
    public float minTimeEvent = 5;
    public float maxTimeEvent = 10;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
