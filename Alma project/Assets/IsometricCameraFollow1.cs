using UnityEngine;

public class IsometricCameraFollow1 : MonoBehaviour
{
    public Transform target; // El objeto a seguir (el personaje)
    public Vector3 offset = new Vector3(0f, 10f, -10f); // Posición de la cámara relativa al personaje
    public float followSpeed = 5f; // Velocidad con la que la cámara sigue al personaje
    public float rotationSpeed = 10f; // Velocidad de rotación de la cámara

    private Vector3 lastDirection; // Dirección previa del movimiento

    void LateUpdate()
    {
        if (target != null)
        {
            FollowTarget();
            // RotateCamera();
        }
    }

    void FollowTarget()
    {
        // Seguir al objetivo con suavidad
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    // void RotateCamera()
    // {
    //     // Obtener la dirección de movimiento del personaje
    //     Vector3 movementDirection = target.GetComponent<PlayerMovement>().transform.forward;

    //     if (movementDirection.magnitude > 0.1f) // Si hay movimiento, actualizar la última dirección
    //     {
    //         lastDirection = movementDirection;
    //     }

    //     // Rotar la cámara hacia la dirección del movimiento
    //     Quaternion targetRotation = Quaternion.LookRotation(lastDirection);
    //     transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    // }
}
