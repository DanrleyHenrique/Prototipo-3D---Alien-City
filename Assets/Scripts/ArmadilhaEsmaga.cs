using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilhaEsmaga : AbstractArmadilha
{
    public MuroParedeEsmaga parede1, parede2;
    private float tempo, tempoAux, tempoFechado, tempoAberto;
    private bool controle, touching, gatilho;

    private float velocidade, tempoDano;

    private bool vitimaDano;
    // Start is called before the first frame update
    void Start()
    {
        vitimaDano = false;
        velocidade = 1.8f; //Velocidade com que as paredes fecham
        tempo = 0;
        tempoFechado = 3;
        tempoAux = 0;
        dano = 10;
        vitima = GameObject.Find("Alien").GetComponent<Player>();
        controle = true;
        touching = false;
        tempoDano = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(vitimaDano == true)
        {
            
            tempoDano -= Time.deltaTime;
           
            if(tempoDano < 0)
            {
                vitima.desativaSistemaDano();
                tempoDano = 1;
                
            }
                
            
        }

        if (gatilho == true && touching == false)
        {
            controle = false;
        }

        if (controle == false && touching == false && tempoAberto <= 0)
        {
            AvancaParede();
            
        }
        else if(controle == true &&  touching == true)
        {
            tempoFechado -= Time.deltaTime;
            if(tempoFechado <= 0)
            {
                RecuaParede();
            }
            
        }
    }

    public void AvancaParede()
    {
        tempo -= Time.deltaTime;

        parede1.transform.Translate(Vector3.right * Time.deltaTime * velocidade);
        parede2.transform.Translate(Vector3.right * Time.deltaTime * velocidade);
    }
    public void RecuaParede()
    {
        tempoFechado = 0;
        tempoAux -= Time.deltaTime;
        
        if (tempoAux > tempo)
        {
            parede1.transform.Translate(Vector3.left * Time.deltaTime * velocidade);
            parede2.transform.Translate(Vector3.left * Time.deltaTime * velocidade);

        }
        else
        {
            
            controle = true;
            touching = false;
            tempoFechado = 3;
            tempoAux = 0;
            tempo = 0;
            
        }
    }

    public override void Dano(Collider collision)
    {

        vitimaDano = true;
        vitima.Dano(dano, 1);
        
    }

    public void PararDano()
    {
        

    }

    public void SetGatilho(bool valor)
    {
        gatilho = valor;
    }

    public void SetControle(bool valor)
    {
        controle = valor;
    }

    public void SetTouching(bool valor)
    {
        touching = valor;
    }
}
