using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform target; // El personaje objetivo (quieto)
    public float speed = 3f; // Velocidad de movimiento del personaje
    public float stopDistance = 1.5f; // Distancia mínima para detenerse al avanzar
    private KeyCode forwardKey = KeyCode.W; // Tecla para avanzar hacia el objetivo
    private KeyCode backwardKey = KeyCode.Q; // Tecla para retroceder

    void Update()
    {
        // Verificar si hay un objetivo
        if (target != null)
        {
            // Calcular la distancia al objetivo
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            // Avanzar hacia el objetivo cuando se presiona la tecla W
            if (Input.GetKey(forwardKey) && distanceToTarget > stopDistance)
            {
                MoveTowardsTarget();
            }

            // Retroceder (alejarse del objetivo) cuando se presiona la tecla Q
            if (Input.GetKey(backwardKey))
            {
                MoveAwayFromTarget();
            }
        }
    }

    private void MoveTowardsTarget()
    {
        // Calcular la dirección hacia el objetivo
        Vector3 direction = (target.position - transform.position).normalized;

        // Mover el personaje hacia el objetivo
        transform.position += direction * speed * Time.deltaTime;

        // Orientar el personaje hacia el objetivo
        RotateTowards(direction);
    }

    private void MoveAwayFromTarget()
    {
        // Calcular la dirección opuesta al objetivo
        Vector3 direction = (transform.position - target.position).normalized;

        // Mover el personaje alejándose del objetivo
        transform.position += direction * speed * Time.deltaTime;

        // Orientar el personaje hacia la dirección opuesta
        RotateTowards(-direction);
    }

    private void RotateTowards(Vector3 direction)
    {
        // Rotar el personaje hacia la dirección especificada
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
    }
}


