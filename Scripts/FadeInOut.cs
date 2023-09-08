using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup canvasgroup;
    public bool fadeIn;
    public bool fadeOut;

    public float timeToFade;
    public void Update()
    {
        // Fade effect is made by changing a canvasgroups alpha from 0 to 1 or viceversa.
        if (fadeIn == true)
        {
            if (canvasgroup.alpha < 1)
            {
                canvasgroup.alpha += timeToFade * Time.deltaTime;
                if (canvasgroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
        if (fadeOut == true)
        {
            if (canvasgroup.alpha >= 0)
            {
                canvasgroup.alpha -= timeToFade * Time.deltaTime;
                if (canvasgroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
    // Starts Fade In
    public void FadeIn()
    {
        fadeIn = true;
    }
    // Starts Fade Out
    public void FadeOut()
    {
        fadeOut = true;
    }
}
