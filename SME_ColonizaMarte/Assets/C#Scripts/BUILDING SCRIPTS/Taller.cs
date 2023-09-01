using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taller : MonoBehaviour
{
    private void Start()
    {
        EstacionDeEnergia.Instance.increaseEnergyAmount();
    }
}
