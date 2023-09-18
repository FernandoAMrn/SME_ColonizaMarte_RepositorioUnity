using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class EstacionDeEnergia : MonoBehaviour 

    ///<summary>
    /// +1 de energia cada luna
    /// 
    /// Tiempo de construccion: 1 luna y media
    /// v
    /// Costo 4 personas
    /// </summary>

{
    public Slider timerSlider;
    public GameObject SliderParaOcultar;
    public GameObject panelDeEnergia;
    public GameObject energyVFX;

    public float sliderTimer;

    public bool stopTimer = false;

    public int energyAmount;
    public TextMeshProUGUI energyAmountText;

    

    public static EstacionDeEnergia Instance;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        

        timerSlider.maxValue = sliderTimer;
        timerSlider.value = sliderTimer;
        StartTimer();

        //Cantidad de energia + UI de energia
        energyAmount = 2;

        energyAmountText.text = energyAmount.ToString();
    }

    public void StartTimer()
    {
        StartCoroutine(StarTheTimerTicker()); //Inicializacion de Corutina del timer
    }
   


    IEnumerator StarTheTimerTicker()
    {
        while (stopTimer == false)
        {
            sliderTimer -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTimer <= 0)
            {
                stopTimer = true; //Timer is over
                SliderParaOcultar.SetActive(false);
                panelDeEnergia.SetActive(true);
                energyVFX.SetActive(true);
                StartCoroutine(energyGen());
                GameManager.Instance.AddPeople(5);
                GameManager.Instance.incresBuildingNumberCount(1);
                GameManager.Instance.TtoaldailyEnergyProducction(4);

                //  TO DO: Regresar cantidad de rovers cuando se acabe el tiempo pero a traves del placement system

            }
            if (stopTimer == false)
            {
                timerSlider.value = sliderTimer; //Timer is running
            }
        }

    }

    IEnumerator energyGen()
    {
        yield return new WaitForSeconds(21);  // TIEMPO DE PRODUCCION
        
        GameManager.Instance.AddEnergy(energyAmount); // CANTIDAD DE ENERGIA PRODUCIDA
        StartCoroutine(energyGen());

    }

   
    public void updateAmountUI()
    {
        energyAmountText.text = energyAmount.ToString();
    }

    public void increaseEnergyAmount()
    {
        energyAmount *= 2;
        updateAmountUI();
    }
    

}
