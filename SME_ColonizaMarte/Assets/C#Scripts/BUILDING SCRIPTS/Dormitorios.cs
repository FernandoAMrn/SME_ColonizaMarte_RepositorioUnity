using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dormitorios : MonoBehaviour
{
    // Start is called before the first frame update
   public void recolectaPersonas()
    {
        ResourceManager.Instance.AddPeople(10);
    }
}
