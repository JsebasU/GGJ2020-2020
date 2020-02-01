using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public PoolObj pool; 
    GameVariables.Desatres desatres = GameVariables.Desatres.Incendios;
    float timer;
    float chaosEvent;
    // Start is called before the first frame update
    private void Awake()
    {
        //pool = FindObjectOfType<PoolObj>();
    }
    void Start()
    {
        chaosEvent = Random.Range(GameManager.manager.minTimeEvent, GameManager.manager.maxTimeEvent);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= chaosEvent)
        {
            Start();
            desatres = (GameVariables.Desatres)Random.Range(0, GameVariables.Desatres.GetNames(typeof(GameVariables.Desatres)).Length - 1);
            Debug.Log(desatres);
            cases();
            timer = 0;
        }
    }
    void cases()
    {
        switch (desatres)
        {
            case GameVariables.Desatres.Meteorito:
            {
                Debug.Log("Meteorito");

                float Point = GetComponent<SphereCollider>().radius;

                    float usedRadius = 0;

                    float x = Random.Range(-Point, Point);
                    usedRadius += Mathf.Abs(x);
                    float y = Random.Range(-(Point-usedRadius), Point - usedRadius);
                    usedRadius += Mathf.Abs(y);
                    int dir = Random.Range(0, 2);
                    float z;
                    if(dir == 0)
                    {
                        z = -(Point - usedRadius);
                    }
                    else
                    {
                        z = Point - usedRadius;
                    }
                    GameObject met = pool.GetObject(GameVariables.METEORITO_PREFAB);
                    met.transform.position = new Vector3(x * (Random.Range(10, 30)), y * (Random.Range(10, 30)), z * (Random.Range(10, 30)));
                    met.transform.SetParent(gameObject.transform);
                    met.SetActive(true);
                    break;
            }
            case GameVariables.Desatres.Incendios:
            {
                Debug.Log("Incendio");

                    mirarPlaneta(GameVariables.INCENDIO_PREFAB);
                    break;
            }
            case GameVariables.Desatres.Pandemia:
            {
                Debug.Log("Pandemia");

                    mirarPlaneta(GameVariables.PANDEMIA_PREFAB);
                    break;
            }
            case GameVariables.Desatres.Volcan:
            {
                Debug.Log("Volcan");

                    mirarPlaneta(GameVariables.VOLCAN_PREFAB);
                    break;
            }
            case GameVariables.Desatres.Radiacion:
            {
                Debug.Log("Radiacion");

                    mirarPlaneta(GameVariables.RADIACION_PREFAB);
                    break;
            }
        }
    }
    
    void mirarPlaneta(string name)
    {
        float Point = GetComponent<SphereCollider>().radius;

        float usedRadius = 0;

        float x = Random.Range(-Point, Point);
        usedRadius += Mathf.Abs(x);
        float y = Random.Range(-(Point - usedRadius), Point - usedRadius);
        usedRadius += Mathf.Abs(y);
        int dir = Random.Range(0, 2);
        float z;
        if (dir == 0)
        {
            z = -(Point - usedRadius);
        }
        else
        {
            z = Point - usedRadius;
        }
        
        GameObject met = pool.GetObject(name);
        met.transform.position = new Vector3(x, y, z);
        met.transform.LookAt(2 * met.transform.position - transform.position);
        met.transform.SetParent(gameObject.transform);
        met.SetActive(true);
    }
}
