using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerSeed : MonoBehaviour
{  
    [SerializeField]
    private TMP_InputField name;
    public void setPlayerSeed(string name)
    {
        int seed = int.Parse(name);
        GameVariables.seed = seed;
    }
}

