using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dormitorios : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(PeopleGen());
    }

    IEnumerator PeopleGen()
    {
        yield return new WaitForSeconds(1200);
        GameManager.Instance.AddPeople(20);
        StartCoroutine(PeopleGen());
    }
}
