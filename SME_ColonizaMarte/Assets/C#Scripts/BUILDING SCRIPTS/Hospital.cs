using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hospital : MonoBehaviour
{

    

    public TextMeshProUGUI numeroDePacientesUI;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownParaCheckeo());    
    }
   

    IEnumerator CountdownParaCheckeo()
    {
        yield return new WaitForSeconds(42);
        ChecaPacientes();
    }


    private void ChecaPacientes()
    {
        if (GameManager.people >= GameManager.food)
        {
            GameManager.Instance.ExpendPeople(3);
            StartCoroutine(DevuelvePersonas());
            StartCoroutine(CountdownParaCheckeo());
        }
        if (GameManager.people <= GameManager.food)
        {
            StartCoroutine(CountdownParaCheckeo());
        }
    }

    IEnumerator DevuelvePersonas()
    {
        yield return new WaitForSeconds(42);
        GameManager.Instance.AddPeople(3);
    }
}
