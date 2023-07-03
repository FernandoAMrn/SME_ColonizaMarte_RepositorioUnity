using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    [Header("UI Elements")]
    [Space(10)]

    //Referencias para UI
    public StandardUIReference peopleUI;

    public StandardUIReference foodUI;

    public StandardUIReference energyUI;
    



    //Singleton
    public static UI_Manager Instance;

    private void Awake()
    {
        //Inicialisar Sigleton
        Instance = this;
    }

    //updetea los UI de recursos
    #region
    /// <summary>
    /// Updates the people UI
    /// </summary>
    /// <param name="currentAmount">setsCurrentAmount</param>
    /// <param name="maxAmount">setsMaxAmount</param>
    public void UpdatePeopleUI(int currentAmount, int maxAmount)
    {
        peopleUI.currentUI.text = currentAmount.ToString();
        peopleUI.maxUI.text = maxAmount.ToString();

        peopleUI.slider.maxValue = maxAmount;
        peopleUI.slider.value = currentAmount;
    }

    /// <summary>
    /// Updates the food UI
    /// </summary>
    /// <param name="currentAmount">setsCurrentAmount</param>
    /// <param name="maxAmount">setsMaxAmount</param>
    public void UpdateFoodUI(int currentAmount, int maxAmount)
    {
        peopleUI.currentUI.text = currentAmount.ToString();
        peopleUI.maxUI.text = maxAmount.ToString();

        peopleUI.slider.maxValue = maxAmount;
        peopleUI.slider.value = currentAmount;
    }

    /// <summary>
    /// Updates the energy UI
    /// </summary>
    /// <param name="currentAmount">setsCurrentAmount</param>
    /// <param name="maxAmount">setsMaxAmount</param>

    public void UpdateEnergydUI(int currentAmount, int maxAmount)
    {
        peopleUI.currentUI.text = currentAmount.ToString();
        peopleUI.maxUI.text = maxAmount.ToString();

        peopleUI.slider.maxValue = maxAmount;
        peopleUI.slider.value = currentAmount;
    }
    #endregion
}

//Classe para referenciar contenedores
[System.Serializable]
public class StandardUIReference
{
    public Slider slider;
    public TMP_Text maxUI;
    public TMP_Text currentUI;
}