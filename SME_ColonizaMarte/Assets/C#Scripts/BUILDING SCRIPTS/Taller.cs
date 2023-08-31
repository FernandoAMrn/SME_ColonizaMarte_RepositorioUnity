using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taller : MonoBehaviour
{
    public EstacionDeEnergia estacionDeEnergia;


    public void Start()
    {
        estacionDeEnergia.energyAmount += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  




}
