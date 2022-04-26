using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class Ship : MonoBehaviour
{
    [SerializeField] float maxSpeedTolerance = 5.0f;
    
    Rigidbody rb;
    float actualSpeed = 0.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.isKinematic = false;
        }

        actualSpeed = rb.velocity.y;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            if (actualSpeed < -maxSpeedTolerance)
            {
                Debug.Log("Se pasó. Velocidad: " + -actualSpeed);
            }
            else
            {
                Debug.Log("Zafó nomás. Velocidad: " + -actualSpeed);
            }
        }
    }
}
