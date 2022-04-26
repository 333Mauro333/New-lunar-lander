using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NewLunarLander
{
    enum DIRECTION { LEFT, RIGHT }

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MovementControls))]

    public class Ship : MonoBehaviour
    {
        [SerializeField] MaterialColorController FloorMCC = null;

        [SerializeField] float maxSpeedTolerance = 5.0f;
        [SerializeField] float accelerationSpeed = 10.0f;
        [SerializeField] float rotationSpeed = 90.0f;


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
            FloorMCC.SetAutomaticColors(new Color(0.25f, 0.25f, 0.25f), Color.white, 0.25f);
        }


        void Update()
        {
            PlayerInput();

            SaveActualSpeed();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                if (IsTooFast())
                {
                    Debug.Log("Se pasó. Velocidad: " + -actualSpeed);
                }
                else
                {
                    Debug.Log("Zafó nomás. Velocidad: " + -actualSpeed);
                }
            }
        }


        void SaveActualSpeed()
        {
            actualSpeed = rb.velocity.y;
        }
        

        void PlayerInput()
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
                Rotate(DIRECTION.LEFT);
            }
            if (Input.GetKey(mc.GetKey(CONTROLS.RIGHT)))
            {
                Rotate(DIRECTION.RIGHT);
            }
        }

        void Accelerate()
        {
            rb.AddForce(transform.up * accelerationSpeed);
        }
        void Rotate(DIRECTION direction)
        {
            Vector3 v3Speed = Vector3.zero;

            switch (direction)
            {
                case DIRECTION.LEFT:
                    v3Speed = new Vector3(0.0f, 0.0f, rotationSpeed) * Time.deltaTime;
                    break;

                case DIRECTION.RIGHT:
                    v3Speed = new Vector3(0.0f, 0.0f, -rotationSpeed) * Time.deltaTime;
                    break;
            }

            rb.MoveRotation(rb.rotation * Quaternion.Euler(v3Speed));
        }

        bool IsTooFast()
        {
            return actualSpeed < -maxSpeedTolerance;
        }
    }
}

