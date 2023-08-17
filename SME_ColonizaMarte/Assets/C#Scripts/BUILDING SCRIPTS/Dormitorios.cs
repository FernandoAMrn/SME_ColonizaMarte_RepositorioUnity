using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey;
using CodeMonkey.MonoBehaviours;
using CodeMonkey.Utils;


public class Dormitorios : MonoBehaviour
{
    public Slider timerSlider;
    public GameObject SliderParaOcultar;

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
        StartCoroutine(StarTheTimerTicker()); //Inicializacion de Corutina del timer
    }

    IEnumerator StarTheTimerTicker()
    {
        while (stopTimer == false)
        {
            sliderTimer -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTimer <= 0)
            {
                stopTimer = true; //Timer is over
                SliderParaOcultar.SetActive(false);
                StartCoroutine(peopleGen());

                //  TO DO: Regresar cantidad de rovers cuando se acabe el tiempo pero a traves del placement system

            }
            if (stopTimer == false)
            {
                timerSlider.value = sliderTimer; //Timer is running
            }
        }
        
    }

    IEnumerator peopleGen()
    {
        yield return new WaitForSeconds(5);
        GameManager.Instance.AddPeople(10);
        StartCoroutine(peopleGen());
    }
}
