using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField]
    private Transform Target;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Target)
        {
            transform.position = Target.TransformPoint(new Vector3(0f, 0.5f, -2.2f));
            transform.LookAt(Target);
        }
    }
}

