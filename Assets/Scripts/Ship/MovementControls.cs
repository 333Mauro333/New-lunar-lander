using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NewLunarLander
{
    public enum CONTROLS { UP, LEFT, RIGHT }
    enum CONTROLS_TYPE { ARROWS, WASD }

    public class MovementControls : MonoBehaviour
    {
        [SerializeField] CONTROLS_TYPE controls = CONTROLS_TYPE.ARROWS;

        KeyCode up = KeyCode.None;
        KeyCode rotateLeft = KeyCode.None;
        KeyCode rotateRight = KeyCode.None;


        void Awake()
        {
            switch (controls)
            {
                case CONTROLS_TYPE.ARROWS:
                    up = KeyCode.UpArrow;
                    rotateLeft = KeyCode.LeftArrow;
                    rotateRight = KeyCode.RightArrow;
                    break;

                case CONTROLS_TYPE.WASD:
                    up = KeyCode.W;
                    rotateLeft = KeyCode.A;
                    rotateRight = KeyCode.D;
                    break;
            }
        }


        public KeyCode GetKey(CONTROLS key)
        {
            switch (key)
            {
                case CONTROLS.UP:
                    return up;

                case CONTROLS.LEFT:
                    return rotateLeft;

                case CONTROLS.RIGHT:
                    return rotateRight;

                default:
                    return KeyCode.None;
            }
        }
    }
}
