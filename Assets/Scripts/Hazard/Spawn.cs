using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public enum Desatres { Meterito, Volcan, Radiacion, Pandemia, Incendios,length };
    public PoolObj pool; 
    Desatres desatres = Desatres.Incendios;
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
            desatres = (Desatres)Random.Range(0, (int)Desatres.length);
            Debug.Log(desatres);
            cases();
            timer = 0;
        }
    }
    void cases()
    {
        switch (desatres)
        {
            case Desatres.Meterito:
            {
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
            case Desatres.Incendios:
            {
                    mirarPlaneta(GameVariables.INCENDIO_PREFAB);
                    break;
            }
            case Desatres.Pandemia:
            {
                    mirarPlaneta(GameVariables.PANDEMIA_PREFAB);
                    break;
            }
            case Desatres.Volcan:
            {
                    mirarPlaneta(GameVariables.VOLCAN_PREFAB);
                    break;
            }
            case Desatres.Radiacion:
            {

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
        /*
        GameObject met = pool.GetObject(name);
        met.transform.position = new Vector3(x, y, z);
        met.transform.LookAt(2 * met.transform.position - transform.position);
        met.transform.SetParent(gameObject.transform);
        met.SetActive(true);*/
    }
}
