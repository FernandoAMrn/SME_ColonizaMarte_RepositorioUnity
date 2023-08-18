using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstacionDeAgua : MonoBehaviour
{
    /// <summary>
    /// +1 de comida cada luna
    /// 
    /// tiempo de construccion: 1 luna
    /// </summary>
    /// 
    public Slider timerSlider;
    public GameObject SliderParaOcultar;

    public float sliderTimer;

    public bool stopTimer = false;


    // Start is called before the first frame update
    void Start()
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
                StartCoroutine(GenAgua());

                //  TO DO: Regresar cantidad de rovers cuando se acabe el tiempo pero a traves del placement system

            }
            if (stopTimer == false)
            {
                timerSlider.value = sliderTimer; //Timer is running
            }
        }

    }

    IEnumerator GenAgua()
    {
        yield return new WaitForSeconds(20);
        GameManager.Instance.AddFood(1);
        StartCoroutine(GenAgua());
    }
    
}
