using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int[] disasterCount;

    private void Start()
    {
        this.disasterCount = new int[GameVariables.Desatres.GetNames(typeof(GameVariables.Desatres)).Length];
    }

    public void CountDisaster(GameVariables.Desatres desastre, bool incrementa = false)
    {
        this.disasterCount[(int) desastre] += incrementa? 1 : -1;
    }
}
