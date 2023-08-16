using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Dormitorios : MonoBehaviour
{
    
    private World_Bar constructingWorldBar;
    private int buildTick;
    private int buildTickMax;
    private bool isConstruccting;

    // Start is called before the first frame update
    private void Start( int ticksToConstruct)
    {
        StartCoroutine(PeopleGen());

        buildTick = 0;
        buildTickMax = ticksToConstruct;
        isConstruccting = true;


        constructingWorldBar = new World_Bar(gameObject.transform, new Vector3(0, 1f), new Vector3(2, 1), Color.grey, Color.yellow, .0f, -10, new World_Bar.Outline() { color = Color.black, size = .01f });
    }

    

    IEnumerator PeopleGen()
    {
        yield return new WaitForSeconds(1200);
        GameManager.Instance.AddPeople(20);
        StartCoroutine(PeopleGen());
    }

    private void BuildingTimeSystem_Onclick(object sender, BuildingTimeSystem.OnTickEventArgs e)
    {
        if (isConstruccting)
        {
            buildTick += 1;
            if (buildTick >= buildTickMax)
            {
                //Building is Fully Constructed
                isConstruccting = false;
                constructingWorldBar.Hide();
            }
            else
            {
                //Building is still construccting
                constructingWorldBar.SetSize(buildTick * 1f / buildTickMax);
            }
        }
    }
}
