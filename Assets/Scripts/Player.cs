using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int vidaPlayer;
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
            vidaPlayer -= valorDano;
            Debug.Log(vidaPlayer);
            interrompeDano = true;
        }


        if(contagemRegressiva)
        {
            tempo -= Time.deltaTime;

            if (tempo <= 0)
            {
                if(dano)
                {                  
                    interrompeDano = false;
                }
                tempo = tempoAux;
                

            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            dano = true;
            contagemRegressiva = dano; // Ativa contagem regressiva
            valorDano = 50;
        }
        if (other.gameObject.tag == "Chao")
        {
            dano = false;
            valorDano = 0;
            contagemRegressiva = !contagemRegressiva;
        }
    }
}
