using UnityEngine;

public class MovVerCohete : MonoBehaviour
{
    public float speedDesplace;
    public float vStars;
    //public int vRotacion = 10;
    public Vector3 rotation;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
        transform.Translate(0, speedDesplace * Time.deltaTime, 0);
    }


}
//413max
//0min
