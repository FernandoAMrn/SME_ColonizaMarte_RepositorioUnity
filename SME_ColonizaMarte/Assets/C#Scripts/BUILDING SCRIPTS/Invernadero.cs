using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invernadero : MonoBehaviour
{
    /// <summary>
    /// El INVERNADERO DA 10 RECURSOS DE COMIDA CADA 30 SEGUNDOS
    /// </summary>
    /// 

    

    private void Start()
    {
        StartCoroutine(recolectComida());
        
    }
    IEnumerator recolectComida()
    {
        yield return new WaitForSeconds(2);

        GameManager.Instance.AddFood(10);
        StartCoroutine(recolectComida());
    }

    
}
