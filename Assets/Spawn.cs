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
            desatres = Desatres.Meterito;
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
                    break;
            }
            case Desatres.Pandemia:
            {
                    break;
            }
            case Desatres.Volcan:
            {
                    break;
            }
            case Desatres.Radiacion:
            {
                    break;
            }
        }
    }
  
    
        
     
}
