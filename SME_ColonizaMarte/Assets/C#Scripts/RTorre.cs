using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTorre : MonoBehaviour
{
    public Vector3 rotation;


    //Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
        this.transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
}
