using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int vidaPlayer;
    float tempo, tempoAux;         // Tempo da contagem regressiva
    public bool dano, contagemRegressiva; //Contagem regressiva para permitir que o player so tome dano apos um determinado tempo

    private int valorDano;
    public Text vida;
    bool interrompeDano;
    public Text pontos;

    private int pontosInt;
    private int chave;
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
        pontosInt = 0;
        chave = 0;

    }

    // Update is called once per frame
    void Update()
    {
        vida.text = "Vida: " + vidaPlayer;
        pontos.text = "Pontuação: " + pontosInt;


        if (dano && contagemRegressiva && interrompeDano == false)
        {
            
            
            Debug.Log("DANO");
            interrompeDano = true;
        }


        if(contagemRegressiva)
        {
            tempo -= Time.deltaTime;
            if (tempo <= 0)
            {
                vidaPlayer -= valorDano;
                tempo = tempoAux;
                interrompeDano = false;
            }
        }  
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pedra")
        {
            pontosInt++;
        }
        if (other.tag == "Chave")
        {
           
            chave++;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        
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

    public void Dano(int x, float t)
    {
        valorDano = x;
        dano = true;
        tempoAux = t;
        tempo = 0;
        contagemRegressiva = true; // Ativa contagem regressiva
    }

    public int GetChaves()
    {
        return chave;
    }

    public int GetVida()
    {
        return vidaPlayer;
    }
}
