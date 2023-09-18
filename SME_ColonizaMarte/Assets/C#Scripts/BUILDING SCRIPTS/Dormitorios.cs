using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Dormitorios : MonoBehaviour 

    ///<summary>
    ///  RESGUARDA A LOS HABITANTES MAX 20 EL JUGADOR NECESITARA CONSTRUIR 5 DE ESTOS PARA RECIBIR A TODAS LAS DEMAS PERSONAS
    ///  
    /// Tiempo de construccion: 2 Lunas
    /// Costo : 4 personas 6 energia
    /// </summary>
{
    public Slider timerSlider;
    public GameObject SliderParaOcultar;
    public GameObject energyExpendPanel;

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
                energyExpendPanel.SetActive(true);
                GameManager.Instance.AddPeople(4);
                GameManager.Instance.incresBuildingNumberCount(1);
                addMaxPeople();
                StartCoroutine(dailyEnergyExpenditure());
                GameManager.Instance.dailyEnergyNumber(6); // Info de consumo diario de energia

                //  TO DO: Regresar cantidad de rovers cuando se acabe el tiempo pero a traves del placement system

            }
            if (stopTimer == false)
            {
                timerSlider.value = sliderTimer; //Timer is running
            }
        }
        
    }

    public void addMaxPeople()
    {
        GameManager.Instance.AddMaxPeople(20);
    }

    IEnumerator dailyEnergyExpenditure()
    {
        yield return new WaitForSeconds(42);
        GameManager.Instance.ExpendEnergy(5);
        StartCoroutine(dailyEnergyExpenditure());
    }
   
}
