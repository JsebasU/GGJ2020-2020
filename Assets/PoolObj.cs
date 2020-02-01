﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObj : MonoBehaviour
{
    GameObject[] volcan;
    [SerializeField] GameObject volcanPrefb;
    GameObject[] meteorito;
    [SerializeField] GameObject meteoritoPrefb;
    GameObject[] radiacion;
    [SerializeField] GameObject radiacionPrefb;
    GameObject[] incendio;
    [SerializeField] GameObject incendioPrefb;
    GameObject[] pandemia;
    [SerializeField] GameObject pandemiaPrefb;

    private void Awake()
    {
        CreatePool(5,volcan,volcanPrefb);
        CreatePool(5,meteorito,meteoritoPrefb);
        CreatePool(5,radiacion,radiacionPrefb);
        CreatePool(5,incendio,incendioPrefb);
        CreatePool(5,pandemia,pandemiaPrefb);
    }

    void CreatePool(int count,GameObject[] pool,GameObject prefab)
    {
        pool = new GameObject[count];
        for(int i = 0; i < count; i++)
        {
            pool[i] = Instantiate(prefab);
            pool[i].SetActive(false);
        }
    }
    /// <summary>
    /// Obtiene un objeto del pool de objetos usando un numero/index para obtener de diferente tipo de pools
    /// </summary>
    /// <param name="prefab">
    /// index para seleccionar de que pool se tomara el objeto
    /// 0 = volcan.
    /// 1 = meteorito.
    /// 2 = radiacion.
    /// 3 = incendio.
    /// 4 = pandemia.
    /// </param>
    /// <returns></returns>
    public GameObject GetObj(int prefab)
    {
        GameObject returnValue = null;
        switch (prefab)
        {
            case 0:
                returnValue = volcan[0];
                UpdatePoolPositions(volcan);
                break;
            case 1:
                returnValue = meteorito[0];
                UpdatePoolPositions(meteorito);
                break;
            case 2:
                returnValue = radiacion[0];
                UpdatePoolPositions(radiacion);
                break;
            case 3:
                returnValue = incendio[0];
                UpdatePoolPositions(incendio);
                break;
            case 4:
                returnValue = pandemia[0];
                UpdatePoolPositions(pandemia);
                break;
            default:
                Debug.LogError("GetObj out of range");
                break;
        }
        return returnValue;
    }

    void UpdatePoolPositions(GameObject[]pool)
    {
        GameObject fstPos = pool[0];
        for(int i = 0; i < pool.Length; i++)
        {
            if(i+1 == pool.Length)
            {
                pool[i] = fstPos;
            }
            else
            {
                pool[i] = pool[i + 1];
            }
        }
    }

}