using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public Transform cameraTransform;

    public float cameraMovementSpeed;
    public float cameraMovementTime;

    // Velocidades para el movimiento de la camara. 
    public float normalSpeed; 
    public float fastSpeed;

    public Vector3 newPosition; // Offset para el rig de la camara
    public Vector3 zoomAmount;
    public Vector3 newZoom;

    private void Start()
    {
        newPosition = transform.position; //Mantiene la posicion de la camara cuando se empieza el juego
        newZoom = cameraTransform.localPosition;
    }

    private void Update()
    {
        CameraMovementInput();
    }

    void CameraMovementInput()  // Controles para la Camara
    {
        // Velocidades de movimiento de la camara
        if (Input.GetKey(KeyCode.LeftShift))
        {
            cameraMovementSpeed = fastSpeed;
        }
        else
        {
            cameraMovementSpeed = normalSpeed;
        }
        // Movimiento de la camara
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
        //Movimiento suave de la camara
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * cameraMovementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * cameraMovementTime);
        //Zoom de la camara
        if (Input.GetKey(KeyCode.R))
        {
            newZoom += zoomAmount;
        }
        if (Input.GetKey(KeyCode.F))
        {
            newZoom -= zoomAmount;
        }
        
    }
}
