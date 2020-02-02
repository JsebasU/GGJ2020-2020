using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoro : MonoBehaviour
{
    Rigidbody rb;
    public float velocity = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.LookAt(Vector3.zero);
        rb.velocity = transform.forward * velocity; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Ground")
        {
            FindObjectOfType<GameController>().KillPopulation((int)(FindObjectOfType<GameController>().actualPopulation*25)/100);
            gameObject.SetActive(false);
        }
        
    }
}
