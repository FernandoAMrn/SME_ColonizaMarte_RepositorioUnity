using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    // FIELDS PARA SISTEMA DE DIA Y NOCHE
    [SerializeField]
    private float timeMultiplier;

    [SerializeField]
    private float startHour;

    [SerializeField]
    private TextMeshProUGUI timeText;

    private DateTime currentTime;
    private TimeSpan sunriseTime;
    private TimeSpan sunsetTime;

    [SerializeField]
    private Light sunLight;

    [SerializeField]
    private float sunRiseHour;
    [SerializeField]
    private float sunsetHour;

    // FIELDS PARA EL CONTADOR DE VICTORIA
    public Slider timerSlider;
    public float sliderTimer;
    

    public bool stopTimer = false;

    public GameObject VictoryPanel;
    public GameObject DefeatPanel;

    

    

    private void Start()
    {
        currentTime = DateTime.Now + TimeSpan.FromHours(startHour); //INICIA EL CONTADOR CON LA HORA ACTUAL

        sunriseTime = TimeSpan.FromHours(sunRiseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);

        //INICIALIZACION DE CONTADOR DE VICOTRIA
        timerSlider.maxValue = sliderTimer;
        timerSlider.value = sliderTimer;
        StartTimer();
        
    }

    private void StartTimer()
    {
        StartCoroutine(StartTheTimerTicker());
    }

    IEnumerator StartTheTimerTicker()
    {
        while (stopTimer == false)
        {
            sliderTimer -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTimer <= 0)
            {
                stopTimer = true; //SE ACABO EL TIEMPO
                if (GameManager.energy >= 100 && GameManager.food >= 100 && GameManager.maxPeople >= 100)
                {
                    VictoryPanel.SetActive(true); //VICTORIA DEL JUEGO
                }
                else
                {
                    DefeatPanel.SetActive(true); //DERROTA DEL JUEGO
                }
            }

            if (stopTimer == false)
            {
                timerSlider.value = sliderTimer; // NO SE HA ACABADO EL TIMEPO

            }
        }
    }
    // UPDATE

    private void Update()
    {
        updateTimeOfDay();
        RotateSun();
        if (GameManager.energy >= 100 && GameManager.food >= 200 && GameManager.maxPeople >= 200)
        {
            VictoryPanel.SetActive(true);
        }

        if (GameManager.food <= -1 || GameManager.energy <= -1)
        {
            DefeatPanel.SetActive(true);
        }

        if (GameManager.energy >= 200)
        {
            GameManager.energy = 200;
        }

        if (GameManager.food >= 200)
        {
            GameManager.food = 200;
        }

        if (GameManager.Instance.BuildingCount >= 20)
        {
            GameManager.Instance.IncreaseFoodCons();
        }

        if (GameManager.Instance.BuildingCount >= 30)
        {
            GameManager.Instance.IncreaseFoodCons2();
        }

    }

    // METODOS DE SISTEMA DE DIA Y NOCHE
    #region
    private void updateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);

        if (timeText != null)
        {
            timeText.text = currentTime.ToString("HH:mm");
        }
    }

    private void RotateSun()
    {
        float sunLightRotation;

        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);
        }
        else
        {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);
        }

        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }

    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan totime)

    {
        TimeSpan difference = totime - fromTime;
        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }
        return difference;
    }

    
    
    #endregion
}
