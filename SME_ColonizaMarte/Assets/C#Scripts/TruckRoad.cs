using UnityEngine;
using System.Collections;

public class TruckRoad : MonoBehaviour
{
    //public float moveSpeed = 2.0f; // Velocidad de movimiento
    //public float maxZ = 0.5f; // Valor máximo en el eje Z
    //public float minZ = -0.5f; // Valor mínimo en el eje Z

    //private bool movingRight = true; // Indica si el objeto se está moviendo hacia la derecha

    //private void Update()
    //{
    //    // Mueve el objeto de izquierda a derecha
    //    if (movingRight)
    //    {
    //        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    //        // Verifica si ha alcanzado el valor máximo
    //        if (transform.position.z >= maxZ)
    //        {
    //            transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
    //            movingRight = false;
    //        }
    //    }
    //    else
    //    {
    //        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

    //        // Verifica si ha alcanzado el valor mínimo
    //        if (transform.position.z <= minZ)
    //        {
    //            transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
    //            movingRight = true;
    //        }
    //    }
    //}

    public float moveSpeed = 2.0f; // Velocidad de movimiento constante
    public float minRotationInterval = 2.0f; // Valor mínimo para el intervalo de rotación en segundos
    public float maxRotationInterval = 10.0f; // Valor máximo para el intervalo de rotación en segundos
    public float minX = -10.0f; // Valor mínimo en el eje X
    public float maxX = 10.0f; // Valor máximo en el eje X
    public float minZ = -3.5f; // Valor mínimo en el eje Z
    public float maxZ = 5.0f; // Valor máximo en el eje Z

    private float rotationTimer = 0.0f; // Temporizador para la rotación
    private float rotationInterval = 0.0f; // Intervalo de rotación actual

    private void Start()
    {
        // Inicializa el temporizador de rotación con un valor aleatorio
        rotationInterval = Random.Range(minRotationInterval, maxRotationInterval);
    }

    private void Update()
    {
        // Mueve el objeto hacia adelante en línea recta
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Verifica si el objeto está dentro del área rectangular
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedZ = Mathf.Clamp(transform.position.z, minZ, maxZ);

        // Actualiza la posición del objeto dentro del área
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);

        // Comienza el temporizador de rotación
        rotationTimer += Time.deltaTime;

        // Si el temporizador alcanza el intervalo de rotación, realiza la rotación
        if (rotationTimer >= rotationInterval)
        {
            // Realiza una rotación de 90 grados en el eje Y
            transform.Rotate(Vector3.up, 90.0f);

            // Reinicia el temporizador de rotación y establece un nuevo intervalo aleatorio
            rotationTimer = 0.0f;
            rotationInterval = Random.Range(minRotationInterval, maxRotationInterval);
        }
    }
}

