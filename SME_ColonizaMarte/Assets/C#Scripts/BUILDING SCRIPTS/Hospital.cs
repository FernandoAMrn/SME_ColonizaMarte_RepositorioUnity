using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hospital : MonoBehaviour
{

    

    public TextMeshProUGUI numeroDePacientesUI;
    public int numeroDePacientes;

    public GameObject healingVFX;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownParaCheckeo());

        numeroDePacientes = 0;
        numeroDePacientesUI.text = numeroDePacientes.ToString();

        
    }
   
    
    IEnumerator CountdownParaCheckeo()
    {
        yield return new WaitForSeconds(42);
        ChecaPacientes();
    }


    private void ChecaPacientes()
    {
        if (GameManager.food <= 0)
        {
            GameManager.Instance.ExpendPeople(3);
            StartCoroutine(DevuelvePersonas());
            StartCoroutine(CountdownParaCheckeo());
            numeroDePacientes = 3;
            updatePacientUI();
            GameManager.Instance.dailyEnergyNumber(6);
            healingVFX.SetActive(true);
        }
        else 
        {
            StartCoroutine(CountdownParaCheckeo());
        }
    }

    IEnumerator DevuelvePersonas()
    {
        yield return new WaitForSeconds(42);
        GameManager.Instance.AddPeople(3);
        numeroDePacientes = 0;
        updatePacientUI();
        GameManager.Instance.dailyEnergyNumber(0);
        healingVFX.SetActive(false);
    }

    public void updatePacientUI()
    {
        numeroDePacientesUI.text = numeroDePacientes.ToString();
    }

    
}
