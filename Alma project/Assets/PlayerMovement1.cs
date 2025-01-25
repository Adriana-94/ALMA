using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidad de movimiento
    public float rotationSpeed = 10f; // Velocidad de rotación

    private CharacterController controller;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveAndRotatePlayer();
    }

    void MoveAndRotatePlayer()
    {
        // Obtener entrada de movimiento
        float moveX = Input.GetAxis("Horizontal"); // A/D o joystick izquierdo (X)
        float moveZ = Input.GetAxis("Vertical");   // W/S o joystick izquierdo (Y)

        // Dirección de movimiento en relación al plano
        Vector3 inputDirection = new Vector3(moveX, 0f, moveZ);

        // Mover al personaje en la dirección deseada
        if (inputDirection.magnitude >= 0.1f)
        {
            // Normalizar para evitar movimientos más rápidos en diagonales
            inputDirection.Normalize();

            // Calcular el movimiento en función de la velocidad
            Vector3 move = inputDirection * moveSpeed * Time.deltaTime;

            // Mover el personaje
            controller.Move(move);

            // Calcular la rotación deseada basada en la dirección del movimiento
            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);

            // Suavizar la rotación hacia la dirección deseada
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
     // Método público para obtener la dirección del movimiento
 
}



