 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerRecursos : MonoBehaviour
{
    public static int maxPeople = 200;
    public static int people = 0;

    public static int maxFood = 200;
    public static int food = 0;

    
    public static int maxEnergy = 200;
    public static int energy = 0;

    public int People { get => people; set => people = value; }
    public int Food { get => food; set => food = value; }
    public int Energy { get => energy; set => energy = value; }

    private void Update()
    {
        Debug.Log(energy + " " + food);
    }
}
