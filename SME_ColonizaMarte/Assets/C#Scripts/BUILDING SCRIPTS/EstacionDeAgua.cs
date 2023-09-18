using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EstacionDeAgua : MonoBehaviour
{
    /// <summary>
    /// +2 de comida cada media luna
    /// 
    /// tiempo de construccion: media  luna
    /// </summary>
    /// 
    public Slider timerSlider;
    public GameObject SliderParaOcultar;
    public GameObject panelAmount;
    public GameObject VFX;

    public float sliderTimer;

    public bool stopTimer = false;


    public int foodAmount;
    public TextMeshProUGUI foodAmountText;
    public static EstacionDeAgua Instance;

    public void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timerSlider.maxValue = sliderTimer;
        timerSlider.value = sliderTimer;

        foodAmount = 2;
        updateNumberUI();
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
                panelAmount.SetActive(true);
                VFX.SetActive(true);
                StartCoroutine(GenAgua());
                StartCoroutine(dailyEnergyExpend());
                GameManager.Instance.AddPeople(2);
                GameManager.Instance.dailyEnergyNumber(2);
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

    IEnumerator GenAgua()
    {
        yield return new WaitForSeconds(21);
        GameManager.Instance.AddFood(foodAmount);
        StartCoroutine(GenAgua());
    }

  
    public void increaseFoodAmount()
    {
        foodAmount *= 2;
        foodAmountText.text = foodAmount.ToString();
    }
    IEnumerator dailyEnergyExpend()
    {
        yield return new WaitForSeconds(42);
        GameManager.Instance.ExpendEnergy(2);
        
        StartCoroutine(dailyEnergyExpend());

    }

    public void updateNumberUI()
    {
        foodAmountText.text = foodAmount.ToString();
    }
    
}
