using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroParedeEsmaga : MonoBehaviour
{

    private ArmadilhaEsmaga armadilha;

    // Start is called before the first frame update
    void Start()
    {
        armadilha = GameObject.Find("Armadilha esmaga").GetComponent<ArmadilhaEsmaga>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "muroEsmaga")
        {
            Debug.Log("PAREDE TOCOOU NA OUTRAO");
            armadilha.SetControle(true);
            armadilha.SetTouching(true);
        }

        if (collision.tag == "Player")
        {
            armadilha.SetControle(true);
            armadilha.SetTouching(true);
            armadilha.RecuaParede();
            armadilha.Dano(collision);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        armadilha.PararDano();
    }
}
