using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Laboratorio : MonoBehaviour
{
    /// <summary>
    /// Duplica la produccion de la estacion de energia más recientemente construida
    /// 
    /// Costo: 7 personas, 10 energia
    /// Tiempo: 2 lunas
    /// </summary>
    /// 

    public Slider timerSlider;
    public GameObject sliderParaOcultar;
    public GameObject VFX;

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
                increaseFoodGen();
                GameManager.Instance.AddPeople(7);


                //  TO DO: Regresar cantidad de rovers cuando se acabe el tiempo pero a traves del placement system

            }
            if (stopTimer == false)
            {
                timerSlider.value = sliderTimer; //Timer is running
            }
        }

    }

    public void increaseFoodGen()
    {
        Invernadero.Instance.increaseFoodAmount();
    }

    
}
