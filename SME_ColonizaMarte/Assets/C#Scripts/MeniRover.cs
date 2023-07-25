using UnityEngine;

public class MeniRover : MonoBehaviour
{
    //Atributos
    public float speed;
    public float speedGainPerSecond;


    // Update is called once per frame
    void Update()
    {
        speed += speedGainPerSecond * Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
