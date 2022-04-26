using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NewLunarLander
{
    [RequireComponent(typeof(Material))]

    public class MaterialColorController : MonoBehaviour
    {
        [SerializeField] Material m = null;
        
        bool automaticColorChange = true;

        Color initialColor;
        Color actualColor;
        Color newColor;

        float rDiff;
        float gDiff;
        float bDiff;

        bool rGoUp;
        bool gGoUp;
        bool bGoUp;

        [SerializeField] float lerpTime;


        void Awake()
        {
            initialColor = m.color;
            actualColor = m.color;
            newColor = m.color;

            rDiff = 0.0f;
            gDiff = 0.0f;
            bDiff = 0.0f;

            rGoUp = false;
            gGoUp = false;
            bGoUp = false;

            lerpTime = 0.0f;
        }
        void Update()
        {
            UpdateColor();
        }


        public void SetNewColor(Color color, float secondsToChange)
        {
            newColor = color;
            lerpTime = secondsToChange;
            automaticColorChange = false;

            AdjustValues();
        }
        public void SetAutomaticColors(Color color1, Color color2, float timeBetweenColor)
        {
            actualColor = color1;
            initialColor = color1;
            newColor = color2;
            lerpTime = timeBetweenColor;
            automaticColorChange = true;

            m.color = actualColor;

            AdjustValues();
        }

        void UpdateColor()
        {
            if (!IsTheSameColor())
            {
                ChangeColor();
            }
        }
        void ChangeColor()
        {
            float valueToChange = rDiff * (Time.deltaTime / lerpTime);
            if (rGoUp)
            {
                actualColor.r = (actualColor.r + valueToChange < newColor.r) ? actualColor.r + valueToChange : newColor.r;
            }
            else
            {
                actualColor.r = (actualColor.r - valueToChange > newColor.r) ? actualColor.r - valueToChange : newColor.r;
            }

            valueToChange = gDiff * (Time.deltaTime / lerpTime);
            if (gGoUp)
            {
                actualColor.g = (actualColor.g + valueToChange < newColor.g) ? actualColor.g + valueToChange : newColor.g;
            }
            else
            {
                actualColor.g = (actualColor.g - valueToChange > newColor.g) ? actualColor.g - valueToChange : newColor.g;
            }

            valueToChange = bDiff * (Time.deltaTime / lerpTime);
            if (bGoUp)
            {
                actualColor.b = (actualColor.b + valueToChange < newColor.b) ? actualColor.b + valueToChange : newColor.b;
            }
            else
            {
                actualColor.b = (actualColor.b - valueToChange > newColor.b) ? actualColor.b - valueToChange : newColor.b;
            }

            m.color = actualColor;

            if (IsTheSameColor() && automaticColorChange)
            {
                Color auxColor = initialColor;
                initialColor = actualColor;
                newColor = auxColor;

                rGoUp = !rGoUp;
                gGoUp = !gGoUp;
                bGoUp = !bGoUp;

                AdjustValues();
            }
        }
        void AdjustValues()
        {
            if (actualColor.r > newColor.r)
            {
                rDiff = actualColor.r - newColor.r;
                rGoUp = false;
            }
            else if (newColor.r > actualColor.r)
            {
                rDiff = newColor.r - actualColor.r;
                rGoUp = true;
            }
            else
            {
                rDiff = 0.0f;
            }

            if (actualColor.g > newColor.g)
            {
                gDiff = actualColor.g - newColor.g;
                gGoUp = false;
            }
            else if (newColor.g > actualColor.g)
            {
                gDiff = newColor.g - actualColor.g;
                gGoUp = true;
            }
            else
            {
                gDiff = 0.0f;
            }

            if (actualColor.b > newColor.b)
            {
                bDiff = actualColor.b - newColor.b;
                bGoUp = false;
            }
            else if (newColor.b > actualColor.b)
            {
                bDiff = newColor.b - actualColor.b;
                bGoUp = true;
            }
            else
            {
                bDiff = 0.0f;
            }
        }

        bool IsTheSameColor()
        {
            return actualColor.r == newColor.r && actualColor.g == newColor.g && actualColor.b == newColor.b;
        }
    }
}
