using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [Header("Resources")]

    [Space(8)]

    //Variables de personas
    public int maxPeople;
    public static int people = 0;

    //Variables de comida
    public int maxFood;
    public static int food = 0;

    //Variables de energia
    public int maxEnergy;
    public static int energy = 0;


    //SINGLETON
    public static ResourceManager Instance;

    private void Awake()
    {
        Instance = this; //Inicializa Singleton
    }

    public bool debugBool = false;

    public int People { get => people; set => people = value; }
    public int Food { get => food; set => food = value; }
    public int Energy { get => energy; set => energy = value; }

    /// <summary>
    /// Añade más recurso de personas al inventario
    /// </summary>
    /// <param name="amount"></param>
    public void AddPeople(int amount)
    {
        People += amount;

        // Actualiza la UI de personas 
        UIManager.Instance.updatePeopleUI(People, maxPeople);
    }

    /// <summary>
    /// Añade más recurso de comida al inventario
    /// </summary>
    /// <param name="amount"></param>
    public void AddFood(int amount)
    {
        Food += amount;
        Debug.Log("Added Food");
        //  Actualiza la UI de comida 
        UIManager.Instance.updateFoodUI(Food, maxFood);
    }

    /// <summary>
    /// Añade más recurso de energia al inventario
    /// </summary>
    /// <param name="amount"></param>
    public void AddEenrgy(int amount)
    {
        Energy += amount;
        Debug.Log("Added energy");
        //  Actualiza la UI de energia
        UIManager.Instance.updateEnergyUI(Energy, maxEnergy);
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
        Debug.Log("personas" + People);
        Debug.Log("comida" + Food);
        Debug.Log("energia" + Energy);
    }
}
