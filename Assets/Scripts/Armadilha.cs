using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilha : AbstractArmadilha
{

    // Start is called before the first frame update
    void Start()
    {
        dano = 5;
        vitima = GameObject.Find("Alien").GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }




    private void OnTriggerEnter(Collider collision)
    {

        Dano(collision);
    }

    void OnTriggerExit(Collider other)
    {
        
           
        
        if (other.tag == "Player")
        {
            
            vitima.desativaSistemaDano();
        }
    }
    



    public override void Dano(Collider collision)
    {
       if(collision.tag == "Player")
        {
            Debug.Log("Armadilha colidiu com " + vitima.tag);
            vitima.Dano(dano, 1);
        }
    }
}
