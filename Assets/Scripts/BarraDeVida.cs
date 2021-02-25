using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarraDeVida : MonoBehaviour
{
    private float vidaMaxima;
    private float vidaMinima;

    public Slider slider;

    private Player jogador;

    public GameObject[] imagensChave;
    private int chaveJogador;

    // Start is called before the first frame update
    void Start()
    {
        vidaMaxima = 100f;
        vidaMinima = 0f;

        slider.minValue = vidaMinima;
        slider.maxValue = vidaMaxima;
        

        jogador = GameObject.Find("Alien").GetComponent<Player>();
        slider.value = jogador.GetVida();

        //imagensChave = new Image[2];
        imagensChave[0].SetActive(false);
        imagensChave[1].SetActive(false);

        chaveJogador = jogador.GetChaves();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = jogador.GetVida();
        
        if (jogador.GetVida() <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(jogador.GetChaves() > chaveJogador)
        {
            imagensChave[chaveJogador].SetActive(true);
            chaveJogador = jogador.GetChaves();
        }
    }
}
