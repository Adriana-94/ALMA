using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidad de movimiento
    public float rotationSpeed = 10f; // Velocidad de rotación
    public float jumpForce = 5f; // Fuerza del salto

    private CharacterController controller;
    private Vector3 moveDirection;
    private float gravity = -9.81f;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Comprobamos si el personaje está tocando el suelo
        isGrounded = controller.isGrounded;
        // if (isGrounded && moveDirection.y < 0)
        // {
        //     moveDirection.y = 0f;
        // }

        // Obtener entrada de movimiento
        float moveX = Input.GetAxis("Horizontal"); // A/D o flechas izquierda/derecha
        float moveZ = Input.GetAxis("Vertical");   // W/S o flechas arriba/abajo

        // Transformar la dirección basada en la orientación de la cámara
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f; // Asegurar que el movimiento esté en el plano horizontal
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Calcular dirección de movimiento
        Vector3 desiredMoveDirection = forward * moveZ + right * moveX;

        // Aplicar movimiento
        controller.Move(desiredMoveDirection * moveSpeed * Time.deltaTime);

        // Aplicar gravedad
        moveDirection.y += gravity * Time.deltaTime;

        // Salto

       if (isGrounded)
       {
        if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
       }

       

        // Aplicar el movimiento vertical (gravedad/salto)
        controller.Move(moveDirection * Time.deltaTime);

        // Rotación del personaje hacia la dirección del movimiento
        // if (desiredMoveDirection.magnitude > 0.1f)
        // {
        //     Quaternion targetRotation = Quaternion.LookRotation(desiredMoveDirection);
        //     transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        // }
    }
}
