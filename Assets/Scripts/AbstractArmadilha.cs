﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractArmadilha : MonoBehaviour
{
    protected int danoValor;
    protected Player vitima;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Dano(Collider vitima);
    

    
}
