using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Taller : MonoBehaviour
{
    /// <summary>
    /// duplica la produccion de la estacion de energia más receientemente construida. 
    /// Tempo de construccion 1 luna
    /// 
    /// 
    /// </summary>
    /// 

    public Slider timerSlider;
    public GameObject sliderParaOcultar;
    public GameObject VFX;

    //TIMER
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
                sliderParaOcultar.SetActive(false);
                VFX.SetActive(true);
                increaseGen();
                
                

                //  TO DO: Regresar cantidad de rovers cuando se acabe el tiempo pero a traves del placement system

            }
            if (stopTimer == false)
            {
                timerSlider.value = sliderTimer; //Timer is running
            }
        }

    }

    public void increaseGen()
    {
        EstacionDeEnergia.Instance.increaseEnergyAmount();
    }
}
