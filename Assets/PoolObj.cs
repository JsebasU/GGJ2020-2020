using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObj : MonoBehaviour
{
    [SerializeField] GameObject[] volcan = new GameObject[0];
    [SerializeField] GameObject volcanPrefb = null;

    [SerializeField] GameObject[] meteorito = new GameObject[0];
    [SerializeField] GameObject meteoritoPrefb = null;

    [SerializeField] GameObject[] radiacion = new GameObject[0];
    [SerializeField] GameObject radiacionPrefb = null;

    [SerializeField] GameObject[] incendio = new GameObject[0];
    [SerializeField] GameObject incendioPrefb = null;

    [SerializeField] GameObject[] pandemia = new GameObject[0];
    [SerializeField] GameObject pandemiaPrefb = null;

    private void Awake()
    {
        volcan = new GameObject[5];
        meteorito = new GameObject[5];
        radiacion = new GameObject[5];
        incendio = new GameObject[5];
        pandemia = new GameObject[5];
    }
    private void Start()
    {
        CreatePool(5, volcan, volcanPrefb);
        CreatePool(5, meteorito, meteoritoPrefb);
        CreatePool(5, radiacion, radiacionPrefb);
        CreatePool(5, incendio, incendioPrefb);
        CreatePool(5, pandemia, pandemiaPrefb);
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

    public void invoke(int index) {
        GameObject x = GetObj(index);
        x.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
    }


}
