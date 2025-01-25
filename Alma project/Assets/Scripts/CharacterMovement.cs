using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad del personaje
    private Animator animator;



    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        // Movimiento del personaje
        if (direction.magnitude > 0)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
            transform.forward = direction; // Apunta en la dirección de movimiento
            animator.SetBool("isWalking", true); // Activa la animación de caminar 
        }

        else

        {
            animator.SetBool("isWalking", false); // Detiene la animación
        }
    }

}
