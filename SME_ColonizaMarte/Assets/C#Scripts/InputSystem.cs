using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public float cameraMovementSpeed;
    public float cameraMovementTime;

    public Vector3 newPosition;

    private void Start()
    {
        newPosition = transform.position; //Mantiene la posicion de la camara cuando se empieza el juego
    }

    private void Update()
    {
        CameraMovementInput();
    }

    void CameraMovementInput()  // Controles para la Camara
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * cameraMovementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -cameraMovementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * cameraMovementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -cameraMovementSpeed);
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * cameraMovementTime); //Movimiento suave de la camara
    }
}
