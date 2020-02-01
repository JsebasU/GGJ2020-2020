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
    private void OnCollisionEnter(Collision collision)
    {
        // -Poblacion
        gameObject.SetActive(false);
    }
}
