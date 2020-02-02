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
        byte[] arr = System.Text.Encoding.ASCII.GetBytes(name);
        int seed = BitConverter.ToInt32(arr, 0) / 1000;
        Debug.Log("Sum " + seed);
        GameVariables.seed = seed;
        material.SetInt("_seed", GameVariables.seed);
    }
   
}
