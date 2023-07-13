using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager_UI : MonoBehaviour
{
    public ManagerRecursos ManagerRecursos;

    public Slider PeopleSlider;
    public TextMeshProUGUI PeopleMaxUI;
    public TextMeshProUGUI PeopleCurrentUI;

    public int currentPeopleAmount = ManagerRecursos.people;
    public int maxPeopleAmount = ManagerRecursos.maxPeople;
    


    public Slider FoodSlider;
    public TextMeshProUGUI FoodMaxUI;
    public TextMeshProUGUI FoodCurrentUI;

    public int currentFoodAmount = ManagerRecursos.food;
    public int maxFoodAmount = ManagerRecursos.maxFood;



    public Slider EnergySlider;
    public TextMeshProUGUI EnergyMaxUI;
    public TextMeshProUGUI EnergyCurrentUI;

    public int currentEnergyAmount = ManagerRecursos.energy;
    public int maxEnergyAmount = ManagerRecursos.maxEnergy;


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
}
