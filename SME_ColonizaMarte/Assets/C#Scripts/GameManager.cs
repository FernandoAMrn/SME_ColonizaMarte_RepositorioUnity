using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;
    [Header("TimerSettings")]
    public float currentTime;
    [Header("Limit Setting")]
    public float timerLimit;
    public GameObject defeatPanel;
    public GameObject NotEnoughResourcesPopUp;


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

    public void AddRovers() // >>>>>>> CAMBIAR FUNCIONAMIENTO DE ROVERS <<<<<<
    {
        if (people >=1 && energy >= 3)
        {
            rovers += 1;
            updateRoverUI(rovers);
            ExpendEnergy(3);
            ExpendPeople(1);
        }
        else // ENVIA POP UP DE QUE FALTAN RECURSOS
        {
            NotEnoughResourcesPopUp.SetActive(true);
            Invoke("notEnoughResourcesApagado", 1.5f); // APAGA EL POP UP DESPUES DE SEGUNDO Y MEDIO

        }


    }

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
    public void ExpendRovers(int amount)
    {
        rovers -= amount;
        
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


        }
        SetTimerText();
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
