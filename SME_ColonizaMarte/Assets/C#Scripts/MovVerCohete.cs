using UnityEngine;

public class MovVerCohete : MonoBehaviour
{
    public float speed;
    public float speedGainPerSecond;
    //public float speedDesplace;
    //public float vStars;
    //public Vector3 rotation;

    // Update is called once per frame
    void Update()
    {

        speed += speedGainPerSecond * Time.deltaTime;
        transform.Translate(0, speed, Time.deltaTime);
        //transform.Rotate(rotation * Time.deltaTime);
        //transform.Translate(0, speedDesplace * Time.deltaTime, 0);
    }


}

