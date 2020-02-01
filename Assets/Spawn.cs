using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public enum Desatres { Meterito, Volcan, Radiacion, Pandemia, Incendios };
    Desatres desatres;
    float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= null)
        {

        }
    }
    void cases()
    {
        switch (desatres)
        {
            case Desatres.Meterito:
            {

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
