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
        [SerializeField] float speed = 10.0f;
        [SerializeField] float rotationSpeed = 90.0f;

        Rigidbody rb;
        MovementControls mc;

        float actualSpeed = 0.0f;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            mc = GetComponent<MovementControls>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.isKinematic = false;
            }
            if (Input.GetKey(mc.GetKey(CONTROLS.UP)))
            {
                Accelerate();
            }
            if (Input.GetKey(mc.GetKey(CONTROLS.LEFT)))
            {
                RotateLeft();
            }

            if (Input.GetKey(mc.GetKey(CONTROLS.RIGHT)))
            {
                RotateRight();
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


        void Accelerate()
        {
            rb.AddForce(transform.up * speed);
        }
        void RotateLeft()
        {
            Vector3 v3Speed = new Vector3(0.0f, 0.0f, rotationSpeed) * Time.deltaTime;

            rb.MoveRotation(rb.rotation * Quaternion.Euler(v3Speed));
            //rb.AddTorque(rotationSpeed);
        }
        void RotateRight()
        {
            Vector3 v3Speed = new Vector3(0.0f, 0.0f, -rotationSpeed) * Time.deltaTime;

            rb.MoveRotation(rb.rotation * Quaternion.Euler(v3Speed));
        }
    }
}

