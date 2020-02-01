using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public enum Desatres { Meterito, Volcan, Radiacion, Pandemia, Incendios };
    public GameObject meteorito;
    public GameObject volcan;
    public GameObject radiacion;
    public GameObject incendio;
    public GameObject Pandemia;
    Desatres desatres = Desatres.Incendios;
    float timer;
    bool Control;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5 && !Control)
        {
            desatres = Desatres.Volcan;
            cases();
            timer = 0;
            Control = true;
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
                    GameObject met = Instantiate(meteorito, new Vector3(x*(Random.Range(10,30)),y * (Random.Range(10, 30)), z * (Random.Range(10, 30))), Quaternion.identity);
                    met.transform.SetParent(gameObject.transform);

                    break;
            }
            case Desatres.Incendios:
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
                    GameObject met = Instantiate(incendio, new Vector3(x , y, z ), Quaternion.identity);
                    transform.LookAt(2 * met.transform.position - transform.position);
                    met.transform.SetParent(gameObject.transform);

                    break;
            }
            case Desatres.Pandemia:
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
                    GameObject met = Instantiate(Pandemia, new Vector3(x, y, z), Quaternion.identity);
                    transform.LookAt(2 * met.transform.position - transform.position);
                    met.transform.SetParent(gameObject.transform);
                    break;
            }
            case Desatres.Volcan:
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
                    GameObject met = Instantiate(volcan, new Vector3(x+ transform.localScale.x, y + transform.localScale.x, z + transform.localScale.x), Quaternion.identity);
                    met.transform.LookAt(2 * met.transform.position - transform.position);
                    met.transform.SetParent(gameObject.transform);
                    break;
            }
            case Desatres.Radiacion:
            {
                    break;
            }
        }
    }
  
    
        
     
}
