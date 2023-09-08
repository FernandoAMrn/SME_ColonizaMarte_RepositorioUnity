using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;
    [Header("TimerSettings")]
    public float currentTime;
    [Header("Limit Setting")]
    public float timerLimit;
    public GameObject defeatPanel;
    public GameObject vitoryPanel;
    public GameObject NotEnoughResourcesPopUp;
    public GameObject firstDropPanel;


    public static int maxPeople = 0;
    public static int people = 0;

    public static int maxFood = 100;
    public static int food = 0;


    public static int maxEnergy = 100;
    public static int energy = 0;

    public static int rovers = 0;
    public int moon;
    public TextMeshProUGUI moonText;



    //PEOPLE UI
    public Slider PeopleSlider;
    public TextMeshProUGUI PeopleMaxUI;
    public TextMeshProUGUI PeopleCurrentUI;

    public int currentPeopleAmount = ManagerRecursos.people;
    public int maxPeopleAmount = ManagerRecursos.maxPeople;


    // FOOD UI
    public Slider FoodSlider;
    public TextMeshProUGUI FoodMaxUI;
    public TextMeshProUGUI FoodCurrentUI;

    public int currentFoodAmount = ManagerRecursos.food;
    public int maxFoodAmount = ManagerRecursos.maxFood;


    // ENERGY UI
    public Slider EnergySlider;
    public TextMeshProUGUI EnergyMaxUI;
    public TextMeshProUGUI EnergyCurrentUI;

    public int currentEnergyAmount = ManagerRecursos.energy;
    public int maxEnergyAmount = ManagerRecursos.maxEnergy;

    // ROVERS UI
    public TextMeshProUGUI RoversCurrentUI;
    public int currentRoversAmount = ManagerRecursos.rovers;

    public Slider timerSlider1;
    public float sliderTiemr1;
    public bool StopTimer1 = false;


    public Slider timerSlider2;
    public float sliderTiemr2;
    public bool StopTimer2 = false;

    public Slider timerSlider3;
    public float sliderTiemr3;
    public bool StopTimer3 = false;

    public Slider timerSlider4;
    public float sliderTiemr4;
    public bool StopTimer4 = false;

    public Slider timerSlider5;
    public float sliderTiemr5;
    public bool StopTimer5 = false;

    public static GameManager Instance; // SINGLETON

    private void Awake()
    {
        Instance = this;
        StartCoroutine(InitialDrop());

        
    }
    private void Start()
    {
        moon = 28;
        updateMoonUI();

        Time.timeScale = 0;

        timerSlider1.maxValue = sliderTiemr1;
        timerSlider1.value = sliderTiemr1;

        timerSlider2.maxValue = sliderTiemr2;
        timerSlider2.value = sliderTiemr2;

        timerSlider3.maxValue = sliderTiemr3;
        timerSlider3.value = sliderTiemr3;

        timerSlider4.maxValue = sliderTiemr4;
        timerSlider4.value = sliderTiemr4;

        timerSlider5.maxValue = sliderTiemr5;
        timerSlider5.value = sliderTiemr5;

    }
   





    //INTERFAZ DE USUARIO
    #region
    public void updatePeopleUI(int currentPeopleAmount, int maxPeopleAmount)
    {
        PeopleCurrentUI.text = currentPeopleAmount.ToString();
        PeopleMaxUI.text = "MAX" + maxPeopleAmount.ToString();


        PeopleSlider.maxValue = maxPeopleAmount;
        PeopleSlider.value = currentPeopleAmount;
    }


    public void updateFoodUI(int currentFoodAmount, int maxFoodAmount)
    {
        FoodCurrentUI.text = currentFoodAmount.ToString();
        FoodMaxUI.text = "MAX" + maxFoodAmount.ToString();


        FoodSlider.maxValue = maxFoodAmount;
        FoodSlider.value = currentFoodAmount;

        
    }

    public void updateEnergyUI(int currentEnergyAmount, int maxAmount)
    {
        EnergyCurrentUI.text = currentEnergyAmount.ToString();
        EnergyMaxUI.text = "MAX" + maxAmount.ToString();


        EnergySlider.maxValue = maxAmount;
        EnergySlider.value = currentEnergyAmount;
    }

    public void updateRoverUI(int currentRoversAmount)
    {
        RoversCurrentUI.text = currentRoversAmount.ToString();
    }
    #endregion

    //GENERA RECURSOS
    #region
    public void AddEnergy(int amount)
    {
        energy += amount;
        updateEnergyUI(energy, maxEnergy);
    }

    public void AddFood(int amount)
    {
        food += amount;
        updateFoodUI(food, maxFood);

    }

    public void AddPeople(int amount)
    {
        people += amount;
        updatePeopleUI(people, maxPeople); 
    }

    public void AddMaxPeople(int amount)
    {
        maxPeople += amount;
        updatePeopleUI(people, maxPeople);
    }

    //ROVERS
    #region
    public void AddRovers1() 
    {
        if (people >=1 && energy >= 3)
        {
            ExpendEnergy(3);
            ExpendPeople(1);
            StartCoroutine(StarTheTimerTicker1());
            StartCoroutine(addsOneRover());
        }
        else // ENVIA POP UP DE QUE FALTAN RECURSOS
        {
            NotEnoughResourcesPopUp.SetActive(true);
            Invoke("notEnoughResourcesApagado", 1.5f); // APAGA EL POP UP DESPUES DE SEGUNDO Y MEDIO

        }


    }

    public void AddRovers2() 
    {
        if (people >= 1 && energy >= 3)
        {
            ExpendEnergy(3);
            ExpendPeople(1);
            StartCoroutine(StarTheTimerTicker2());
            StartCoroutine(addsOneRover());
        }
        else // ENVIA POP UP DE QUE FALTAN RECURSOS
        {
            NotEnoughResourcesPopUp.SetActive(true);
            Invoke("notEnoughResourcesApagado", 1.5f); // APAGA EL POP UP DESPUES DE SEGUNDO Y MEDIO

        }


    }

    public void AddRovers3()
    {
        if (people >= 1 && energy >= 3)
        {
            ExpendEnergy(3);
            ExpendPeople(1);
            StartCoroutine(StarTheTimerTicker3());
            StartCoroutine(addsOneRover());
        }
        else // ENVIA POP UP DE QUE FALTAN RECURSOS
        {
            NotEnoughResourcesPopUp.SetActive(true);
            Invoke("notEnoughResourcesApagado", 1.5f); // APAGA EL POP UP DESPUES DE SEGUNDO Y MEDIO

        }
    }

    public void AddRovers4()
    {
        if (people >= 1 && energy >= 3)
        {
            ExpendEnergy(3);
            ExpendPeople(1);
            StartCoroutine(StarTheTimerTicker4());
            StartCoroutine(addsOneRover());
        }
        else // ENVIA POP UP DE QUE FALTAN RECURSOS
        {
            NotEnoughResourcesPopUp.SetActive(true);
            Invoke("notEnoughResourcesApagado", 1.5f); // APAGA EL POP UP DESPUES DE SEGUNDO Y MEDIO

        }
    }

    public void AddRovers5()
    {
        if (people >= 1 && energy >= 3)
        {
            ExpendEnergy(3);
            ExpendPeople(1);
            StartCoroutine(StarTheTimerTicker5());
            StartCoroutine(addsOneRover());
        }
        else // ENVIA POP UP DE QUE FALTAN RECURSOS
        {
            NotEnoughResourcesPopUp.SetActive(true);
            Invoke("notEnoughResourcesApagado", 1.5f); // APAGA EL POP UP DESPUES DE SEGUNDO Y MEDIO

        }
    }

    IEnumerator StarTheTimerTicker1()
    {
        while (StopTimer1 == false)
        {
            sliderTiemr1 -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTiemr1 <= 0)
            {
                StopTimer1 = true; //Timer is over
                
            }
            if (StopTimer1 == false)
            {
                timerSlider1.value = sliderTiemr1; //Timer is running
            }
        }
    }

    IEnumerator StarTheTimerTicker2()
    {
        while (StopTimer2 == false)
        {
            sliderTiemr2 -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTiemr2 <= 0)
            {
                StopTimer2 = true; //Timer is over

            }
            if (StopTimer2 == false)
            {
                timerSlider2.value = sliderTiemr2; //Timer is running
            }
        }
    }

    IEnumerator StarTheTimerTicker3()
    {
        while (StopTimer3 == false)
        {
            sliderTiemr3 -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTiemr3 <= 0)
            {
                StopTimer3 = true; //Timer is over

            }
            if (StopTimer3 == false)
            {
                timerSlider3.value = sliderTiemr3; //Timer is running
            }
        }
    }

    IEnumerator StarTheTimerTicker4()
    {
        while (StopTimer4 == false)
        {
            sliderTiemr4 -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTiemr4 <= 0)
            {
                StopTimer4 = true; //Timer is over

            }
            if (StopTimer4 == false)
            {
                timerSlider4.value = sliderTiemr4; //Timer is running
            }
        }
    }
    IEnumerator StarTheTimerTicker5()
    {
        while (StopTimer5 == false)
        {
            sliderTiemr5 -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTiemr5 <= 0)
            {
                StopTimer5 = true; //Timer is over

            }
            if (StopTimer5 == false)
            {
                timerSlider5.value = sliderTiemr5; //Timer is running
            }
        }
    }

    IEnumerator addsOneRover()
    {
        yield return new WaitForSeconds(42);
        AddPeople(2);
        rovers += 1;
        updateRoverUI(rovers);


    }


    #endregion
    //TERMINA ROVERS
    #endregion

    //  QUITA RECURSOS

    public void ExpendPeople(int amount)
    {
        people -= amount;
        updatePeopleUI(people, maxPeople);
    }

    IEnumerator ConsumeFood()
    {
        yield return new WaitForSeconds(42);
        food -= 20;
        moon -= 1;
        updateMoonUI();
        updateFoodUI(food, maxFood);
        StartCoroutine(ConsumeFood());

        

    }

    public void ExpendEnergy(int amount)
    {
        energy -= amount;
        updateEnergyUI(energy, maxEnergy);
    }
    

    public void notEnoughResourcesApagado()  // DESACTIVA EL POP UP DE RECURSOS
    {
        NotEnoughResourcesPopUp.SetActive(false);
    }

    //TIMER DE NAVE CON RECURSOS
    public void Update()
    {
        currentTime = currentTime -= Time.deltaTime;

        if (currentTime <= timerLimit)
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
            firstDropPanel.SetActive(false);

        }
        SetTimerText();
        if (maxPeople >= 100 && food >= 100 && energy >= 100)
        {
            vitoryPanel.SetActive(true);
        }
        if (food <= 0)
        {
            defeatPanel.SetActive(false);
        }
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }

    //Drop de recursos incial
    IEnumerator InitialDrop()
    {
        yield return new WaitForSeconds(12);
        AddPeople(20);
        AddFood(60);

        StartCoroutine(ConsumeFood());
    }

    private void updateMoonUI()
    {
        moonText.text = moon.ToString();
    }



}
