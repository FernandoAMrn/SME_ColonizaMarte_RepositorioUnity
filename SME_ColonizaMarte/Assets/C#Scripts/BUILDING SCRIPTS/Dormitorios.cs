using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Dormitorios : MonoBehaviour
{
    
    private World_Bar constructingWorldBar;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(PeopleGen());
        constructingWorldBar = new World_Bar(gameObject.transform, new Vector3(0, 1f), new Vector3(2, 1), Color.grey, Color.yellow, .0f, -10, new World_Bar.Outline() { color = Color.black, size = .01f });
    }

    

    IEnumerator PeopleGen()
    {
        yield return new WaitForSeconds(1200);
        GameManager.Instance.AddPeople(20);
        StartCoroutine(PeopleGen());
    }
}
