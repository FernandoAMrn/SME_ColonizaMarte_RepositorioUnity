using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Invernadero : MonoBehaviour
{
    /// <summary>
    ///  +2 de comida cada luna
    ///  
    /// Tiempo de construccion: 3 lunas
    /// </summary>
    /// 

    //Timer de construccion
    public Slider timerSlider;
    public GameObject SliderParaOcultar;
    public GameObject panelDeComida;
    public GameObject FoodVFX;

    public float sliderTimer;

    public bool stopTimer = false;
    //Timer de Construccion

    //UI de catidad
    public int foodAmount;
    public TextMeshProUGUI foodAmountText;

    public static Invernadero Instance;

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        timerSlider.maxValue = sliderTimer;
        timerSlider.value = sliderTimer;
        StartTimer();

        foodAmount = 4;

        foodAmountText.text = foodAmount.ToString();
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
                panelDeComida.SetActive(true);
                FoodVFX.SetActive(true);
                StartCoroutine(GenInvernadero());
                GameManager.Instance.AddPeople(3);

                //  TO DO: Regresar cantidad de rovers cuando se acabe el tiempo pero a traves del placement system

            }
            if (stopTimer == false)
            {
                timerSlider.value = sliderTimer; //Timer is running
            }
        }

    }

    IEnumerator GenInvernadero()
    {
        yield return new WaitForSeconds(42); // NUMERO DE SEGUNDOS DE PRODUCCION

        GameManager.Instance.AddFood(foodAmount); // CANTIDAD DE COMIDA PRODUCCIDA
        StartCoroutine(GenInvernadero());
    }

    public void updateFoodUI()
    {
        foodAmountText.text = foodAmount.ToString();
    }
    public void increaseFoodAmount()
    {
        foodAmount *= 2;
        updateFoodUI();
    }

    
}
