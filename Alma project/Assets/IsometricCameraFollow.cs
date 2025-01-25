using UnityEngine;

public class IsometricCameraFollow : MonoBehaviour
{
    public Transform target; // El objeto a seguir (el personaje)
    public Vector3 offset = new Vector3(10f, 10f, -10f); // Posición de la cámara relativa al personaje
    public float followSpeed = 5f; // Velocidad con la que la cámara sigue al personaje

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcular la posición objetivo de la cámara
            Vector3 targetPosition = target.position + offset;

            // Suavizar el movimiento de la cámara
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // Orientar la cámara hacia el personaje (opcional)
            transform.LookAt(target.position);
        }
    }
}
