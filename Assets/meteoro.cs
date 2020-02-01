using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteoro : MonoBehaviour
{
    Rigidbody rb;
    public float velocity = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.LookAt(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * velocity; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Ocean")
        {
            GameManager.manager.poblacion = GameManager.manager.poblacion - ((GameManager.manager.poblacion * Random.Range(10, 15)) / 100);
            gameObject.SetActive(false);
        }
        else if (gameObject.tag == "Ground")
        {
            GameManager.manager.poblacion = GameManager.manager.poblacion - ((GameManager.manager.poblacion * Random.Range(10, 30)) / 100);
            gameObject.SetActive(false);
        }
        
    }
}
