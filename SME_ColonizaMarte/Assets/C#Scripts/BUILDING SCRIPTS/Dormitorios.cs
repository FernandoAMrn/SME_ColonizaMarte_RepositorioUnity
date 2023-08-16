using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dormitorios : MonoBehaviour
{
    public Slider timerSlider;

    public float sliderTimer;

    public bool stopTimer = false;


    private void Start()
    {
        timerSlider.maxValue = sliderTimer;
        timerSlider.value = sliderTimer;
        StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(StarTheTimerTicker());
    }

    IEnumerator StarTheTimerTicker()
    {
        while (stopTimer == false)
        {
            sliderTimer -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTimer <= 0)
            {
                stopTimer = true;
            }
            if (stopTimer == false)
            {
                timerSlider.value = sliderTimer;
            }
        }
        
    }
}
