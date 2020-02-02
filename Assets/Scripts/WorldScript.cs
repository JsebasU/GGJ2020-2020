using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
    private Material material;
    void Start()
    {
        material = GetComponent<Material>();
    }

    public void changeSeed(string name)
    {
        int seed = int.Parse(name);
        GameManager.manager.seed = seed;
        material.SetInt("_seed",GameManager.manager.seed);
    }
   
}
