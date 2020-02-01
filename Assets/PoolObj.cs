using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoolObj : MonoBehaviour
{
    [SerializeField] GameObject volcanPrefb;
    [SerializeField] GameObject meteoritoPrefb = null;
    [SerializeField] GameObject radiacionPrefb = null;
    [SerializeField] GameObject incendioPrefb = null;
    [SerializeField] GameObject pandemiaPrefb = null;

    public Dictionary<string, GameObject> Pool = new Dictionary<string, GameObject>();
    
    public int poolSize = 5;

    private void Start()
    {
        CreatePool(volcanPrefb, poolSize);
        CreatePool(meteoritoPrefb, poolSize);
        CreatePool(radiacionPrefb, poolSize);
        CreatePool(incendioPrefb, poolSize);
        CreatePool(pandemiaPrefb, poolSize);
    }

    void CreatePool(GameObject prefab, int size)
    {
        for (int i = 0; i < size; i++)
        {
            Pool.Add(prefab.name + i, Instantiate(prefab, this.transform));
        }
    }

    public GameObject GetFromPool(string name)
    {
        if (Pool.ContainsKey(name))
        {
            GameObject newObject;
            Pool.TryGetValue(name, out newObject);
            return newObject;
        }
        return null;
    }
    
    /*
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
    */
    public void invoke(string name)
    {
        if (Pool.ContainsKey(name))
        {
            GameObject x = GetFromPool(name);
            x.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
        }
    }


}
