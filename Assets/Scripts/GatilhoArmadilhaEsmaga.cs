using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoArmadilhaEsmaga : MonoBehaviour
{
    private bool controle;
    private ArmadilhaEsmaga armadilha;
    // Start is called before the first frame update
    void Start()
    {
        controle = false;
        armadilha = GameObject.Find("Armadilha esmaga").GetComponent<ArmadilhaEsmaga>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("colidu");
            armadilha.SetGatilho(true);
        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            
            armadilha.SetGatilho(false);
        }

    }


    public bool GetControle()
    {
        return controle;
    }
}