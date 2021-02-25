using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilhaEspinhos : AbstractArmadilha
{
    public GameObject chao1, chao2;
    private float tempo, tempoAux, tempoFechado;
    // Start is called before the first frame update
    void Start()
    {
        tempoAux = 5;
        tempo = 5;
        
        tempoFechado = 3;
        danoValor = 15;
        vitima = GameObject.Find("Alien").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        tempoFechado -= Time.deltaTime;
        if(tempoFechado < 0)
        {
            tempo -= Time.deltaTime;
            if (tempo > 0)
            {

                chao1.transform.Translate(Vector3.left * Time.deltaTime * 1);
                chao2.transform.Translate(Vector3.right * Time.deltaTime * 1);


            }

            if (tempo <= 0)
            {


                if (tempo <= -2f)
                {
                    chao1.transform.Translate(Vector3.right * Time.deltaTime * 1);
                    chao2.transform.Translate(Vector3.left * Time.deltaTime * 1);
                    if (tempo <= (-tempoAux + (-2f))) //tempo <= -7
                    {

                        tempoFechado = 3;
                        tempo = tempoAux;
                    }
                }
            }
        }
            
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
        if (collision.tag == "Player")
        {
            Debug.Log("Armadilha colidiu com " + vitima.tag);
            vitima.Dano(danoValor, 3f);
        }
    }
}
