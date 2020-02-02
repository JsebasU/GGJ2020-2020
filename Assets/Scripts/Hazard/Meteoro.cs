using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoro : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] ParticleSystem particula;
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
        if(other.gameObject.tag == "Ground")
        {
            FindObjectOfType<GameController>().KillPopulation((int)(FindObjectOfType<GameController>().actualPopulation*25)/100);
            StartCoroutine(Delay());
        }
        
    }
    IEnumerator Delay()
    {
        particula.Play();
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
