using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EstacionDeEnergia : MonoBehaviour 

    ///<summary>
    /// +1 de energia cada luna
    /// 
    /// Tiempo de construccion: 2 lunas
    /// </summary>

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
                StartCoroutine(energyGen());

                //  TO DO: Regresar cantidad de rovers cuando se acabe el tiempo pero a traves del placement system

            }
            if (stopTimer == false)
            {
                timerSlider.value = sliderTimer; //Timer is running
            }
        }

    }

    IEnumerator energyGen()
    {
        yield return new WaitForSeconds(2);  // TIEMPO DE PRODUCCION
        //ManagerRecursos.energy += 10;
        GameManager.Instance.AddEnergy(10); // CANTIDAD DE ENERGIA PRODUCIDA
        StartCoroutine(energyGen());

    }
}
