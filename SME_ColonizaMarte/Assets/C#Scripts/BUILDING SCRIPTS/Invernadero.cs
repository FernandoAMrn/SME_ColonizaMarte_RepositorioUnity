using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Invernadero : MonoBehaviour
{
    /// <summary>
    ///  +5 de comida cada luna
    ///  
    /// Tiempo de construccion: 2 lunas
    /// 
    /// Costo: 4 personas 3 energia
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

    

    private void Start()
    {
        timerSlider.maxValue = sliderTimer;
        timerSlider.value = sliderTimer;
        StartTimer();

        foodAmount = 5;

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
                StartCoroutine(dailyEnergyExpenditure());
                GameManager.Instance.dailyEnergyNumber(4);// Info de Consumo diario de energia
                GameManager.Instance.AddPeople(4);
                GameManager.Instance.incresBuildingNumberCount(1);
                GameManager.Instance.TotalDailyFoodProdduction(foodAmount);

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
    IEnumerator dailyEnergyExpenditure()
    {
        yield return new WaitForSeconds(42);
        GameManager.Instance.ExpendEnergy(3);
        StartCoroutine(dailyEnergyExpenditure());
    }

}
