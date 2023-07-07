using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTorre : MonoBehaviour
{
    public float rSpeed;
    private float totalRot = 0f;
    //Update is called once per frame
    void Update()
    {
        if (totalRot <15)
        {
            float rotationAmount = -rSpeed * Time.deltaTime;
            transform.Rotate(rotationAmount, 0f, 0f);
            totalRot += Mathf.Abs(rotationAmount);
        }
    }
}
