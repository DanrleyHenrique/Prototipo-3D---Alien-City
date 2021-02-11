using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPropriedades : MonoBehaviour
{
    private GameObject player;
    AudioSource audioSource;
    float rotacaoY = 0f;
    float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4f);
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();

        transform.localScale = new Vector3(0.1f, 0.1f, 0.05f);
        rotacaoY = player.transform.eulerAngles.y;
        transform.Rotate(0.0f, rotacaoY, 0.0f);

        //Debug.Log(rotacaoY);

        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Quebravel")
        {
            Destroy(gameObject, 0f);
            //Debug.Log("TIro bateu na parede");
        }
    }
}
