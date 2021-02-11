using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuebravelPorTiro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Tiro")
        {
            Destroy(gameObject, 0f);
            
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colidiu com " + collision.gameObject.name);
    }
}
