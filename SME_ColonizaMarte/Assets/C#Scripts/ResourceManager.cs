using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [Header("Resources")]

    [Space(10)]

    public int maxPeople;
    int people = 0;

    public int maxFood;
    int food = 0;

    public int maxEnergy;
    int energy = 0;

    public static ResourceManager Instance;

    private void Awake()
    {
        //Inicializo Singleton
        Instance = this;
    }

    /// <summary>
    /// Add more food to inventory
    /// </summary>
    /// <param name="amount"></param>
    public void AddFood(int amount)
    {
        people += amount;

        //Updates the food UI
        UI_Manager.Instance.UpdateFoodUI(food, maxFood);
    }

    /// <summary>
    /// Add more food to inventory
    /// </summary>
    /// <param name="amount"></param>
    public void AddEnergy(int amount)
    {
        energy += amount;

        //Updates the energy UI
        UI_Manager.Instance.UpdateEnergydUI(energy, maxEnergy);
    }

}
