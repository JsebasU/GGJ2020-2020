using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
    private Material material;
    public GameManager GameManager;
    void Start()
    {
        this.material = GetComponent<MeshRenderer>().material;
        if (this.GameManager == null)
            this.GameManager = FindObjectOfType<GameManager>();
    }

    public void changeSeed(string name)
    {

        int seed = name.GetHashCode() % 1000;
        Debug.Log("Sum " + seed);
        GameVariables.seed = seed;
        material.SetInt("_seed", GameVariables.seed);
    }
   
}
