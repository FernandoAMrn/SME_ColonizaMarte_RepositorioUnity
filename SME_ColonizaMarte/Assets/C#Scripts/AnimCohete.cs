using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCohete : MonoBehaviour
{
    //    public float ascendSpeed = 2.0f;      // Velocidad de ascenso inicial
    //    public float descendSpeed = 2.0f;     // Velocidad de descenso
    //    public float maxAscendSpeed = 5.0f;   // Velocidad m�xima de ascenso
    //    public float pauseDuration = 2.0f;    // Duraci�n de la pausa en segundos
    //    public float ascendHeight = 20.0f;    // Altura m�xima de ascenso

    //    private Vector3 initialPosition;      // Posici�n inicial
    //    private bool isAscending = true;      // Indica si est� ascendiendo
    //    private bool isPaused = false;        // Indica si est� en pausa
    //    private float startTime;              // Tiempo de inicio
    //    private float currentSpeed;           // Velocidad actual

    //    private void Start()
    //    {
    //        initialPosition = transform.position;
    //        startTime = Time.time;
    //        currentSpeed = 0f;
    //    }

    //    private void Update()
    //    {
    //        float distanceCovered = (Time.time - startTime);

    //        if (isAscending)
    //        {
    //            // Ascender con velocidad gradual
    //            currentSpeed = Mathf.Lerp(0, maxAscendSpeed, distanceCovered / ascendSpeed);
    //            float currentHeight = Mathf.Lerp(0, ascendHeight, distanceCovered * currentSpeed);
    //            transform.position = initialPosition + Vector3.up * currentHeight;

    //            if (currentHeight >= ascendHeight)
    //            {
    //                // El objeto ha alcanzado la altura m�xima, realizar pausa
    //                isAscending = false;
    //                isPaused = true;
    //                startTime = Time.time;
    //            }
    //        }
    //        else if (isPaused)
    //        {
    //            // En pausa est�tica
    //            if (Time.time - startTime >= pauseDuration)
    //            {
    //                // Finaliz� la pausa est�tica, comenzar a descender
    //                isPaused = false;
    //                startTime = Time.time;
    //            }
    //        }
    //        else
    //        {
    //            // Descender con velocidad gradual hasta que la velocidad sea nula
    //            currentSpeed = Mathf.Lerp(maxAscendSpeed, 0, distanceCovered / descendSpeed);
    //            float currentHeight = Mathf.Lerp(ascendHeight, 0, distanceCovered * currentSpeed);
    //            transform.position = initialPosition + Vector3.up * currentHeight;
    //        }
    //    }
    public float descendSpeed = 2.0f; // Velocidad de descenso inicial
    public float staticDuration = 2.0f; // Duraci�n en segundos en estado est�tico
    public float ascendAcceleration = 1.0f; // Aceleraci�n al ascender

    private Vector3 initialPosition; // Posici�n inicial
    private float staticTimer; // Temporizador para el estado est�tico
    private bool isDescending = true; // Indica si est� descendiendo
    private bool isStatic = false; // Indica si est� en estado est�tico

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isDescending)
        {
            // Calcula el desplazamiento en esta actualizaci�n
            float displacement = descendSpeed * Time.deltaTime;
            float newY = Mathf.Max(transform.position.y - displacement, 0f);

            // Actualiza la posici�n
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Detiene el objeto cuando llega al punto de origen
            if (newY <= 0)
            {
                // Asegura que el objeto est� exactamente en el punto de origen
                transform.position = new Vector3(initialPosition.x, 0, initialPosition.z);
                isDescending = false;
                isStatic = true;
                staticTimer = Time.time;
            }
        }
        else if (isStatic)
        {
            // Permanece est�tico durante el tiempo especificado
            if (Time.time - staticTimer >= staticDuration)
            {
                isStatic = false;

                // Comienza a ascender con aceleraci�n
                descendSpeed = 0.0f; // Detiene cualquier movimiento descendente
            }
        }
        else
        {
            // Aumenta gradualmente la velocidad de ascenso
            descendSpeed += ascendAcceleration * Time.deltaTime;

            // Calcula el desplazamiento en esta actualizaci�n
            float displacement = descendSpeed * Time.deltaTime;
            float newY = Mathf.Min(transform.position.y + displacement, initialPosition.y);

            // Actualiza la posici�n
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}
