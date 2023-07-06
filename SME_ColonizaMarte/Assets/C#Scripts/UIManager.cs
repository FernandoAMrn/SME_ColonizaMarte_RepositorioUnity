using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [Space(10)]
    /*Referencias para UI*/
    public StandardUIReference peopleUI;

    public StandardUIReference foodUI;

    public StandardUIReference energyUI;


    //SINGLETON
    public static UIManager Instance;
    private void Awake()
    {
       Instance = this; //Inicializa singleton
    }


    /// <summary>
    /// Updatea el UI de las personas
    /// </summary>
    /// <param name="currentAmount">sete el valora ctual del slider y texto</param>
    /// <param name="maxAmount">setea el valor maximo del slider y texto</param>
    public void updatePeopleUI(int currentAmount,  int maxAmount)
    {
        //Setea el texto en el UI
        peopleUI.currentUI.text =  currentAmount.ToString();
        peopleUI.maxUI.text = "MAX" + maxAmount.ToString();

        //Setea el slider  en el UI
        peopleUI.slider.maxValue = maxAmount;
        peopleUI.slider.value = currentAmount;
    }

    /// <summary>
    /// Updatea el UI de la comida
    /// </summary>
    /// <param name="currentAmount">sete el valora ctual del slider y texto</param>
    /// <param name="maxAmount">setea el valor maximo del slider y texto</param>
    public void updatefoodUI(int currentAmount, int maxAmount)
    {
        //Setea el texto en el UI
        foodUI.currentUI.text = currentAmount.ToString();
        foodUI.maxUI.text = "MAX" + maxAmount.ToString();

        //Setea el slider  en el UI
        foodUI.slider.maxValue = maxAmount;
        foodUI.slider.value = currentAmount;
    }

    /// <summary>
    /// Updatea el UI de la energia
    /// </summary>
    /// <param name="currentAmount">sete el valora ctual del slider y texto</param>
    /// <param name="maxAmount">setea el valor maximo del slider y texto</param>
    public void updateEnergyUI(int currentAmount, int maxAmount)
    {
        //Setea el texto en el UI
        energyUI.currentUI.text = currentAmount.ToString();
        energyUI.maxUI.text = "MAX" + maxAmount.ToString();

        //Setea el slider  en el UI
        energyUI.slider.maxValue = maxAmount;
        energyUI.slider.value = currentAmount;
    }

    void UpdateAllUI()
    {
        updatePeopleUI(ResourceManager.Instance.People, ResourceManager.Instance.maxPeople);
        updatePeopleUI(ResourceManager.Instance.Food, ResourceManager.Instance.maxFood);
        updatePeopleUI(ResourceManager.Instance.Energy, ResourceManager.Instance.maxEnergy);

        /* AQUI ME QUEDE
         * 
         * MIN 25:42 */
    }

    //Clase para referencias de UI

    [System.Serializable]
    public class StandardUIReference
    {
        
        public Slider slider;
        public TextMeshProUGUI maxUI;
        public TextMeshProUGUI currentUI;
    }

}
