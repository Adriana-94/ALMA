using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform target; // El personaje objetivo (quieto)
    public float normalSpeed = 3f; // Velocidad normal de movimiento
    public float acceleratedSpeed = 6f; // Velocidad acelerada
    public float stopDistance = 1.5f; // Distancia mínima para detenerse al avanzar
    public GameObject dialogPanel; // Panel de diálogo
    private KeyCode forwardKey = KeyCode.W; // Tecla para avanzar hacia el objetivo
    private KeyCode backwardKey = KeyCode.Q; // Tecla para retroceder
    private KeyCode accelerateKey = KeyCode.LeftShift; // Tecla para acelerar el paso

    private float currentSpeed; // Velocidad actual del personaje

    private ParticleSystem polvoPies;

    private ParticleSystem.EmissionModule emisionPolvoPies;
    private bool tocaSuelo;


    void Start()
    {
        // Asegurarse de que el panel de diálogo esté desactivado al inicio
        if (dialogPanel != null)
        {
            dialogPanel.SetActive(false);

            emisionPolvoPies = polvoPies.emission;

            

        }
    }
    void Update()
        {
        // Verificar si hay un objetivo
        if (target != null)
        {
            // Calcular la distancia al objetivo
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            // Mostrar el cuadro de diálogo si el personaje está dentro de la distancia de parada
            if (distanceToTarget <= stopDistance)
            {
                dialogPanel.SetActive(true);
            }
            else
            {
                dialogPanel.SetActive(false);
            }

            // Establecer la velocidad actual según si se presiona la tecla para acelerar
            currentSpeed = Input.GetKey(accelerateKey) ? acceleratedSpeed : normalSpeed;

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
            {
                CheckpolvoPies();
                float W = Input.GetKey(forwardKey) ? 1 : 0;
            }
        }
    }


    private void CheckpolvoPies() 
    {
        if (tocaSuelo && forwardKey != 0)
        {

            emisionPolvoPies.rateOverTime = 35;
        }
        else emisionPolvoPies.rateOverTime = 0;
    }
    private void MoveTowardsTarget()
    {
        // Calcular la dirección hacia el objetivo
        Vector3 direction = (target.position - transform.position).normalized;

        // Mover el personaje hacia el objetivo
        transform.position += direction * currentSpeed * Time.deltaTime;

        // Orientar el personaje hacia el objetivo
        RotateTowards(direction);
    }

    private void MoveAwayFromTarget()
    {
        // Calcular la dirección opuesta al objetivo
        Vector3 direction = (transform.position - target.position).normalized;

        // Mover el personaje alejándose del objetivo
        transform.position += direction * currentSpeed * Time.deltaTime;

        // Orientar el personaje hacia la dirección opuesta
        RotateTowards(-direction);
    }

    private void RotateTowards(Vector3 direction)
    {
        // Rotar el personaje hacia la dirección especificada
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * normalSpeed);
    }
}
