using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NewLunarLander
{

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MovementControls))]

    public class Ship : MonoBehaviour
    {
        [SerializeField] float maxSpeedTolerance = 5.0f;

        Rigidbody rb;
        MovementControls mc;

        float actualSpeed = 0.0f;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            mc = GetComponent<MovementControls>();
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(mc.GetKey(CONTROLS.UP)))
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
}

