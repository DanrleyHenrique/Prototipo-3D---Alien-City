﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera MyCamera;
    private Animator anim;
    private float velocidade, velocidadeDeRotacao = 3f;

    CharacterController MyController;
    private bool mov;

    float rotacaoDesejada = 0f;
    float gravidade;

    float velocidadeY = 0f;
    bool pulando = false;

    float velocidadeDePulo = 12f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        MyController = GetComponent<CharacterController>();
        velocidade = 3.5f;
        gravidade = -0.4f;
        MyCamera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //MyCamera.transform.position = transform.position;

        if (Player.vidaPlayer <= 0)
        {
            velocidade = 0;
            velocidadeDeRotacao = 0;
            anim.SetTrigger("Morre");
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //Debug.Log("X: " + x + " Z: " + z); //z frente e para tras

        /*MyCamera.transform.position = new Vector3((transform.position.x), transform.position.y + 1.1f, transform.position.z - 2.2f);


        if (z == 1) // Controle de camera
        {
            //para frente
            //MyCamera.transform.position = new Vector3((transform.position.x), transform.position.y + 1.1f, transform.position.z - 2.2f);
            
        }
        else if(z ==  -1)
        {
            // para tras
            //MyCamera.transform.eulerAngles = new Vector3(x, 0, z);
            //MyCamera.transform.position = new Vector3((transform.position.x), transform.position.y + 1.1f, transform.position.z - 2.2f);
            //MyCamera.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        */




        if (Input.GetButtonDown("Jump") && !pulando && Player.vidaPlayer > 0)
        {
            pulando = true;
            velocidadeY += velocidadeDePulo;
        }
        if (!MyController.isGrounded)
        { 
            velocidadeY += gravidade + Time.deltaTime;
        }
        else if(velocidadeY < 0)
        {
            velocidadeY = 0;
        }


        
        
        if (MyController.isGrounded)
        {
            pulando = false;
        }

        Vector3 movimento = new Vector3(x,0,z);
        Vector3 movimentoVertical = Vector3.up * velocidadeY;

        if (movimento != Vector3.zero)
        {
            mov = true;
        }
        else
        {
            mov = false;
        }

        //Vector3 rotacaoMovimento = Quaternion.Euler(0, MyCamera.transform.rotation.eulerAngles.y, 0) * movimento;
        if (z >= 0)
        {
            Vector3 rotacaoMovimento = Quaternion.Euler(0, MyCamera.transform.rotation.eulerAngles.y, 0) * movimento;
            MyController.Move((movimentoVertical + (rotacaoMovimento * velocidade)) * Time.deltaTime);

            if (rotacaoMovimento.magnitude > 0)
            {
                rotacaoDesejada = Mathf.Atan2(rotacaoMovimento.x, rotacaoMovimento.z) * Mathf.Rad2Deg;

            }
            Quaternion rotacaoAtual = transform.rotation;
            Quaternion rotacaoAlvo = Quaternion.Euler(0, rotacaoDesejada, 0);
            transform.rotation = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, velocidadeDeRotacao * Time.deltaTime);
        }
        else if(z < 0)
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (Time.deltaTime * z*velocidade));
            Vector3 rotacaoMovimento = Quaternion.Euler(0, MyCamera.transform.rotation.eulerAngles.y, 0) * movimento;
            MyController.Move((movimentoVertical + (rotacaoMovimento * velocidade)) * Time.deltaTime);

            
        }
    }

    void FixedUpdate()
    {
        if(mov)
        {
            anim.SetTrigger("Corre");
        }
        else if (Input.GetButtonDown("Jump") && !pulando)
        {
            anim.SetTrigger("Pula");
        }
        
        
        else
        {
            
            anim.SetTrigger("Parado");
        }
    }

    

}
