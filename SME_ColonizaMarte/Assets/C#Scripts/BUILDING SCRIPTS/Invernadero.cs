using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invernadero : MonoBehaviour
{
    /// <summary>
    /// El INVERNADERO DA 10 RECURSOS DE COMIDA CADA 30 SEGUNDOS
    /// </summary>
   public void recolectComida()
    {
        ResourceManager.Instance.AddFood(10);
    }
}
