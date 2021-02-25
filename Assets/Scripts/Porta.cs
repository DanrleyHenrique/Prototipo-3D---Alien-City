using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    protected Player jogador;
    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.Find("Alien").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log(jogador.GetChaves());
        if (collision.tag == "Player" && jogador.GetChaves() == 2)
        {
            Destroy(gameObject, 0f);
        }

    }
}
