using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int vidaPlayer;
    float tempo, tempoAux;         // Tempo da contagem regressiva
    bool dano, contagemRegressiva; //Contagem regressiva para permitir que o player so tome dano apos um determinado tempo

    int valorDano;
    public Text vida;
    bool interrompeDano;

   
    // Start is called before the first frame update
    void Start()
    {
        vidaPlayer = 100;
        tempoAux = 3f;
        tempo = tempoAux;
        dano = false;
        valorDano = 0;
        contagemRegressiva = false;
        interrompeDano = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        vida.text = "Vida: " + vidaPlayer;


        if (dano && contagemRegressiva && interrompeDano == false)
        {
            valorDano = 50;
            vidaPlayer -= valorDano;
            vida.text = "Vida: " + vidaPlayer;

            Debug.Log("DANO");
            interrompeDano = true;
        }


        if(contagemRegressiva)
        {
            tempo -= Time.deltaTime;
            if (tempo <= 0)
            { 
                tempo = tempoAux;
                interrompeDano = false;
            }
        }  
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {

            dano = true;
            contagemRegressiva = true; // Ativa contagem regressiva
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            Debug.Log("SAIU DA LAVA");
            desativaSistemaDano();
        }
    }


   

    public void desativaSistemaDano()
    {
        dano = false;
        valorDano = 0;
        contagemRegressiva = !contagemRegressiva;
        interrompeDano = true;
        tempo = 0;
    }

    public void diminuiVida()
    {

    }
}
