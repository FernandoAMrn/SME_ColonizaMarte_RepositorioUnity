using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstacionDeEnergia : MonoBehaviour
{
    //public void recolectaEnergia()
    //{
    //    ResourceManager.Instance.AddEenrgy(10);
    //}


    private void Start()
    {
        StartCoroutine(energyGen());
    }


    IEnumerator energyGen()
    {
        yield return new WaitForSeconds(2);
        ManagerRecursos.energy += 10;
        StartCoroutine(energyGen());

    }
}
