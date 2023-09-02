using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCohete : MonoBehaviour
{
    public float ascendSpeed = 2.0f;      // Velocidad de ascenso inicial
    public float descendSpeed = 2.0f;     // Velocidad de descenso
    public float maxAscendSpeed = 5.0f;   // Velocidad máxima de ascenso
    public float pauseDuration = 2.0f;    // Duración de la pausa en segundos
    public float ascendHeight = 20.0f;    // Altura máxima de ascenso

    private Vector3 initialPosition;      // Posición inicial
    private bool isAscending = true;      // Indica si está ascendiendo
    private bool isPaused = false;        // Indica si está en pausa
    private float startTime;              // Tiempo de inicio
    private float currentSpeed;           // Velocidad actual

    private void Start()
    {
        initialPosition = transform.position;
        startTime = Time.time;
        currentSpeed = 0f;
    }

    private void Update()
    {
        float distanceCovered = (Time.time - startTime);

        if (isAscending)
        {
            // Ascender con velocidad gradual
            currentSpeed = Mathf.Lerp(0, maxAscendSpeed, distanceCovered / ascendSpeed);
            float currentHeight = Mathf.Lerp(0, ascendHeight, distanceCovered * currentSpeed);
            transform.position = initialPosition + Vector3.up * currentHeight;

            if (currentHeight >= ascendHeight)
            {
                // El objeto ha alcanzado la altura máxima, realizar pausa
                isAscending = false;
                isPaused = true;
                startTime = Time.time;
            }
        }
        else if (isPaused)
        {
            // En pausa estática
            if (Time.time - startTime >= pauseDuration)
            {
                // Finalizó la pausa estática, comenzar a descender
                isPaused = false;
                startTime = Time.time;
            }
        }
        else
        {
            // Descender con velocidad gradual hasta que la velocidad sea nula
            currentSpeed = Mathf.Lerp(maxAscendSpeed, 0, distanceCovered / descendSpeed);
            float currentHeight = Mathf.Lerp(ascendHeight, 0, distanceCovered * currentSpeed);
            transform.position = initialPosition + Vector3.up * currentHeight;
        }
    }
}
