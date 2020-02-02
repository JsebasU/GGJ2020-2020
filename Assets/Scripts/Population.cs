using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{
    int poblacion = 1000;
    public PoolObj pool;
    void Update()
    {
        if(GameVariables.poblacion > poblacion)
        {
            mirarPlaneta(GameVariables.CASA_PREFAB);
            poblacion += 10;
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
        met.transform.position = new Vector3(x+((met.transform.localScale.x)*2), y + ((met.transform.localScale.x) * 2), z + ((met.transform.localScale.x) * 2));
        met.transform.LookAt(2 * met.transform.position - transform.position);
        met.transform.SetParent(gameObject.transform);
        met.SetActive(true);
    }
}
