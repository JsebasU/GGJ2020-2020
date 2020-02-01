using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoolObj : MonoBehaviour
{
    public Dictionary<string, Stack<GameObject>> Pool = new Dictionary<string,  Stack<GameObject>>();
    
    public int poolSize = 5;
    public int poolExtraSize = 3;

    private void Start()
    {
        Debug.Log("Starting Pool");
        CreatePool(GameVariables.VOLCAN_PREFAB, poolSize);
        CreatePool(GameVariables.METEORITO_PREFAB, poolSize);
        CreatePool(GameVariables.RADIACION_PREFAB, poolSize);
        CreatePool(GameVariables.INCENDIO_PREFAB, poolSize);
        //CreatePool((GameObject) Resources.Load(GameVariables.PANDEMIA_PREFAB), poolSize);
    }
    
    void CreatePool(string prefabPath, int size)
    {
        Debug.Log("Creating Pool");
        GameObject newGameObject = (GameObject) Resources.Load(prefabPath);
        Stack<GameObject> newStack = new Stack<GameObject>();
        for (int i = 0; i < size; i++)
        {
            GameObject newObject = Instantiate(newGameObject, this.transform);
            newObject.name.Replace("(Clone)", "");
            newStack.Push(newObject);
        }
        Pool.Add(prefabPath, newStack);
        Debug.Log("Pool Created " + prefabPath);
    }

    public void IncreasePoolSize(string poolName, int newSize)
    {
        if (Pool.ContainsKey(poolName))
        {
            Stack<GameObject> stack;
            Pool.TryGetValue(poolName, out stack);
            for (int i = 0; i < newSize; i++)
            {
                GameObject newObject = Instantiate((GameObject) Resources.Load(poolName), this.transform);
                newObject.SetActive(false);
                newObject.name.Replace("(Clone)", "");
                stack.Push(newObject);
            }
            Debug.Log("Increased the poolsize correctly!");
        }
    }

    public GameObject GetObject(string name)
    {
        Start:
        Debug.Log("Getting Object");
        if (Pool.ContainsKey(name))
        {
            Stack<GameObject> newObject;
            Pool.TryGetValue(name, out newObject);
            if (newObject.Count < 1)
            {
                IncreasePoolSize(name, poolExtraSize);
                goto Start;
            }
            return newObject.Pop();
        }
        return null;
    }

    public void ReleaseObject(GameObject usedObject)
    {
        Debug.Log("Releasing Object");
        if (Pool.ContainsKey(usedObject.name))
        {
            Stack<GameObject> newObject;
            Pool.TryGetValue(name, out newObject);
            if(newObject != null)
                newObject.Push(usedObject);
            else
                Debug.Log("No pool found for this object, ??");
        }
        else
        {
            Debug.Log("WTF!, this object isn't poolable");
        }
    }
    
    public void invoke(string name)
    {
        Debug.Log("Request object");
        if (Pool.ContainsKey(name))
        {
            GameObject x = GetObject(name);
            Debug.Log("Request object " + x);
            x.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
        }
    }


}
