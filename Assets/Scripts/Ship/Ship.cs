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
        [SerializeField] float rotationLimit = 45.0f;

        [SerializeField] string victoryFloorTag = "";

        [SerializeField] Transform cameraPosition;
        [SerializeField] Vector3 diff;


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

            cameraPosition.position = transform.position - diff;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(victoryFloorTag))
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
        void OnCollisionStay(Collision collision)
        {
            rb.angularVelocity = Vector3.zero;
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
            // Inicializo la variable local que va a sumar la rotación en el frame actual.
            Vector3 v3Speed = Vector3.zero;

            // Deine si la rotación va hacia la izquierda o hacia la derecha.
            switch (direction)
            {
                case DIRECTION.LEFT:
                    v3Speed = new Vector3(0.0f, 0.0f, rotationSpeed) * Time.deltaTime;
                    break;

                case DIRECTION.RIGHT:
                    v3Speed = new Vector3(0.0f, 0.0f, -rotationSpeed) * Time.deltaTime;
                    break;
            }

            // Suma la rotación.
            //if (CanTurn(direction))
            //{
            //    rb.MoveRotation(rb.rotation * Quaternion.Euler(v3Speed));
            //}
            //else
            //{
            //    v3Speed = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rotationLimit);
            //    rb.rotation = Quaternion.Euler(v3Speed);
            //}

            // Suma la rotación.
            rb.MoveRotation(rb.rotation * Quaternion.Euler(v3Speed));

            if (rb.rotation.z > rotationLimit / 90.0f)
            {
                Debug.Log("IZQUIERDA (" + rb.rotation.z + ")");
            }
            else if (rb.rotation.z < rotationLimit / -90.0f)
            {
                Debug.Log("DERECHA (" + rb.rotation.z + ")");
            }
            else
            {
                Debug.Log("NADA");
            }
        }

        bool IsTooFast()
        {
            return actualSpeed < -maxSpeedTolerance;
        }
        bool CanTurn(DIRECTION direction)
        {
            switch (direction)
            {
                case DIRECTION.LEFT:
                    return rb.rotation.z + rotationSpeed * Time.deltaTime < rotationLimit / 90.0f;

                case DIRECTION.RIGHT:
                    return rb.rotation.z - rotationSpeed * Time.deltaTime > rotationLimit / -90.0f;
            }

            return true;
        }
    }
}

