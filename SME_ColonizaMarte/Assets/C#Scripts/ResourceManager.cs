using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [Header("Resources")]

    [Space(8)]

    //Variables de personas
    public int maxPeople;
    int people = 0;

    //Variables de comida
    public int maxFood;
    int food = 0;

    //Variables de energia
    public int maxEnergy;
    int energy = 0;


    //SINGLETON
    public static ResourceManager Instance;

    private void Awake()
    {
        Instance = this; //Inicializa Singleton
    }

    public bool debugBool = false;

    /// <summary>
    /// Añade más recurso de personas al inventario
    /// </summary>
    /// <param name="amount"></param>
    public void AddPeople(int amount)
    {
        people += amount;

        // Actualiza la UI de personas 
        UIManager.Instance.updatePeopleUI(people, maxPeople);
    }

    /// <summary>
    /// Añade más recurso de comida al inventario
    /// </summary>
    /// <param name="amount"></param>
    public void AddFood(int amount)
    {
        food += amount;

        //  Actualiza la UI de comida 
        UIManager.Instance.updatefoodUI(food, maxFood);
    }

    /// <summary>
    /// Añade más recurso de energia al inventario
    /// </summary>
    /// <param name="amount"></param>
    public void AddEenrgy(int amount)
    {
        energy += amount;

        //  Actualiza la UI de energia
        UIManager.Instance.updateEnergyUI(energy, maxEnergy);
    }


    private void Update()
    {
        if (debugBool)
        {
            printCurrentResources();
            debugBool = false;
        }
    }

    void printCurrentResources()
    {
        Debug.Log("personas" + people);
        Debug.Log("comida" + food);
        Debug.Log("energia" + energy);
    }
}
