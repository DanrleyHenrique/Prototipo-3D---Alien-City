using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera MyCamera;
    private float velocidade;
    CharacterController MyController; 
    // Start is called before the first frame update
    void Start()
    {
        MyController = GetComponent<CharacterController>();
        velocidade = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movimento = new Vector3(x,0,z);
        Vector3 rotacaoMovimento = Quaternion.Euler(0, MyCamera.transform.rotation.eulerAngles.y, 0) * movimento;
        MyController.Move(rotacaoMovimento * velocidade * Time.deltaTime);

        if(rotacaoMovimento.magnitude > 0)
        {
            float anguloDeMovimento = Mathf.Atan2(rotacaoMovimento.x, rotacaoMovimento.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, anguloDeMovimento, 0);
        }
    }
}
