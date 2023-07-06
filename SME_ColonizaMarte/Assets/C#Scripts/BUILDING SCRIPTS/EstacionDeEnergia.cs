using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstacionDeEnergia : MonoBehaviour
{
     public void recolectaEnergia()
    {
        ResourceManager.Instance.AddEenrgy(10);
    }
}
