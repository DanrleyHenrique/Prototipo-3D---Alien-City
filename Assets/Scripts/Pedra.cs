using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedra : MonoBehaviour
{
    protected int velocidade;
    
    // Start is called before the first frame update
    void Start()
    {
        
        velocidade = 20;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(5.0f * Time.deltaTime, 0.0f, 0.0f, Space.Self);
        //transform.Rotate(Vector3.right * Time.deltaTime * velocidade);
        transform.Rotate(0, 0, velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject, 0f);
        }
        
    }
}
