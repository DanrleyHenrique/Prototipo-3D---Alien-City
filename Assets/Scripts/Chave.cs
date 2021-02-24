using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : Pedra
{
    // Start is called before the first frame update
    void Start()
    {
        velocidade = -50;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, velocidade * Time.deltaTime, 0);
    }
}
