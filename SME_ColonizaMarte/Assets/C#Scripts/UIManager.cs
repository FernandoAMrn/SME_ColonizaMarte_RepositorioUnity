using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [Space(10)]
    /*Referencias for UI*/
    public StandardUIReference peopleUI;

    public StandardUIReference foodUI;

    public StandardUIReference energyUI;


    //SINGLETON
    public static UIManager Instance;
    private void Awake()
    {
       Instance = this; //Inicializa singleton
    }


    //Class para referencias de UI

    [System.Serializable]
    public class StandardUIReference
    {
        public Slider slider;
        public TMP_Text maxUI;
        public TMP_Text curentUI;
    }

}
