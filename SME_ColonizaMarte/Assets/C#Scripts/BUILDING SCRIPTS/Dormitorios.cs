using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dormitorios : MonoBehaviour
{
    public Image timer_linear_image;
    float timeRemaining;
    public float maxTime = 20.0f;
    private bool isConstruccting;

    // Start is called before the first frame update
    private void Start()
    {
        timeRemaining = maxTime;
        StartCoroutine(PeopleGen());
        
    }

    

    IEnumerator PeopleGen()
    {
        yield return new WaitForSeconds(1200);
        GameManager.Instance.AddPeople(20);
        StartCoroutine(PeopleGen());
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timer_linear_image.fillAmount = timeRemaining / maxTime;
        }
    }

}
