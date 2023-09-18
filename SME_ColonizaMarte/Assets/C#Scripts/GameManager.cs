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


    public static int maxPeople = 20;
    public static int people = 0;

    public static int maxFood = 200;
    public static int food = 0;


    public static int maxEnergy = 200;
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

    public int dailyFoodProdduction;
    public int dailyFoodConsumption;

    public Slider dailyFoodProducction_Slider;
    public TextMeshProUGUI dailyFoodProducction_Text;
    public TextMeshProUGUI dailyFoodConsumption_Text;
    public int BuildingCount;
    public TextMeshProUGUI buildingCount_Text;

    // ENERGY UI
    public Slider EnergySlider;
    public TextMeshProUGUI EnergyMaxUI;
    public TextMeshProUGUI EnergyCurrentUI;

    public int currentEnergyAmount = ManagerRecursos.energy;
    public int maxEnergyAmount = ManagerRecursos.maxEnergy;
    public int dailyenergyExpenditure;
    public int dailyEnergyProduction;

    public TextMeshProUGUI energyExpenditure_Text;
    public TextMeshProUGUI dailyEnergyProducction_Text;

    public Slider dailyEnergyExpenditure_Sldier;
    public Slider dailyEnergyProdduction_Slider;

    // ROVERS UI
    public TextMeshProUGUI RoversCurrentUI;
    public int currentRoversAmount = ManagerRecursos.rovers;

    public Slider timerSlider1;
    public float sliderTiemr1;
    public bool StopTimer1 = false;


    public GameObject roverButton1;
    public GameObject roverButton2;
    public GameObject roverButton3;
    public GameObject roverButton4;
    public GameObject roverButton5;
    public GameObject roverButton6;


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

    public int dailyRoverEnergy;
    public TextMeshProUGUI roversEnergyCost;

    public static GameManager Instance; // SINGLETON

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            
        }
        else
        {
            Instance = this;
            
        }
        
        
        defeatPanel.SetActive(false);
        
    }
    private void Start()
    {
        moon = 28;
        updateMoonUI();

        StartCoroutine(InitialDrop());
        //StartCoroutine(increaseFoodConsumption2());
        //StartCoroutine(increaseFoodConsumption1());

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

        //ROVER INFO UI
        dailyRoverEnergy = 0;
        roversEnergyCost.text = dailyRoverEnergy.ToString();

        dailyenergyExpenditure = 0;
        energyExpenditure_Text.text = dailyenergyExpenditure.ToString();

        dailyEnergyProduction = 0;
        dailyEnergyProducction_Text.text = dailyEnergyProduction.ToString();

        //FOOD INFO UI
        dailyFoodProdduction = 0;
        dailyFoodProducction_Slider.maxValue = maxFood;
        dailyFoodProducction_Slider.value = dailyFoodProdduction;

        dailyFoodProducction_Text.text = dailyFoodProdduction.ToString();

        dailyFoodConsumption = 20;
        dailyFoodConsumption_Text.text = dailyFoodConsumption.ToString();

        BuildingCount = 0;
        buildingCount_Text.text = BuildingCount.ToString();
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
            StartCoroutine(buttonActive1());
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
            roverButton2.SetActive(true);
            roverButton3.SetActive(false);
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
            roverButton3.SetActive(true);
            roverButton4.SetActive(false);
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
            roverButton4.SetActive(true);
            roverButton5.SetActive(false);
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
            roverButton5.SetActive(true);
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
                dailyRoverEnergy += 1;
                roversEnergyCost.text = dailyRoverEnergy.ToString();
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
                dailyRoverEnergy += 1;
                roversEnergyCost.text = dailyRoverEnergy.ToString();
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
                dailyRoverEnergy += 1;
                roversEnergyCost.text = dailyRoverEnergy.ToString();
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
                dailyRoverEnergy += 1;
                roversEnergyCost.text = dailyRoverEnergy.ToString();
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
                dailyRoverEnergy += 1;
                roversEnergyCost.text = dailyRoverEnergy.ToString();
            }
            if (StopTimer5 == false)
            {
                timerSlider5.value = sliderTiemr5; //Timer is running
            }
        }
    }

    IEnumerator addsOneRover()
    {
        yield return new WaitForSeconds(80);
        AddPeople(2);
        rovers += 1;
        updateRoverUI(rovers);
        

    }

    IEnumerator buttonActive1()
    {
        yield return new WaitForSeconds(2);                                     // BOTONES DE ROVE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        roverButton1.SetActive(true);
        roverButton2.SetActive(false);
    }

    IEnumerator buttonActive2()
    {
        yield return new WaitForSeconds(2);                                     // BOTONES DE ROVE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        roverButton2.SetActive(true);
        roverButton3.SetActive(false);
    }

    IEnumerator buttonActive3()
    {
        yield return new WaitForSeconds(2);                                     // BOTONES DE ROVE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        roverButton3.SetActive(true);
        roverButton4.SetActive(false);
    }

    IEnumerator buttonActive4()
    {
        yield return new WaitForSeconds(2);                                     // BOTONES DE ROVE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        roverButton4.SetActive(true);
        roverButton5.SetActive(false);
    }
    IEnumerator buttonActive5()
    {
        yield return new WaitForSeconds(2);                                     // BOTONES DE ROVE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        roverButton5.SetActive(true);
        roverButton6.SetActive(false);
    }

    IEnumerator dailyRoverEnergyExpenditure()
    {
        yield return new WaitForSeconds(42);
        ExpendEnergy(dailyRoverEnergy);
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
        food -= dailyFoodConsumption;
        moon -= 1;
        updateMoonUI();
        updateFoodUI(food, maxFood);
        StartCoroutine(ConsumeFood());

        

    }

    

    public void IncreaseFoodCons()
    {
        dailyFoodConsumption = 40;
        dailyFoodConsumption_Text.text = dailyFoodConsumption.ToString();
    }

    public void IncreaseFoodCons2()
    {
        dailyFoodConsumption = 60;
        dailyFoodConsumption_Text.text = dailyFoodConsumption.ToString();
    }
    public void incresBuildingNumberCount(int amount)
    {
        BuildingCount += amount;
        buildingCount_Text.text = BuildingCount.ToString();
    }
    public void ExpendEnergy(int amount)
    {
        energy -= amount;
        updateEnergyUI(energy, maxEnergy);
    }
    
    public void dailyEnergyNumber(int amount) //Numero de gasto de energia diario
    {
        dailyenergyExpenditure += amount;
        energyExpenditure_Text.text = dailyenergyExpenditure.ToString();
        dailyEnergyExpenditure_Sldier.maxValue = maxEnergy;
        dailyEnergyExpenditure_Sldier.value = dailyenergyExpenditure;

    }

    public void TtoaldailyEnergyProducction(int amount)  //Numero de produccion de energia diaria
    {
        dailyEnergyProduction += amount;
        dailyEnergyProducction_Text.text = dailyEnergyProduction.ToString();
        dailyEnergyProdduction_Slider.maxValue = maxEnergy;
        dailyEnergyProdduction_Slider.value = dailyEnergyProduction;
    }

    public void TotalDailyFoodProdduction(int amount)
    {
        dailyFoodProdduction += amount;
        dailyFoodProducction_Text.text = dailyFoodProdduction.ToString();
        dailyFoodProducction_Slider.value = dailyFoodProdduction;
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
        if (maxPeople >= 100 && food >= 200 && energy >= 200)
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
        AddFood(80);
        StartCoroutine(ConsumeFood());
    }

    private void updateMoonUI()
    {
        moonText.text = moon.ToString();
    }



}
