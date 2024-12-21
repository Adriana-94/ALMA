using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmaMovimiento : MonoBehaviour
{
    public float speedMovement = 5.0f;
    [SerializeField] private float speedRotate = 200.0f;
    [SerializeField] private float movX;
    [SerializeField] private float movY;

    private Rigidbody rb;

    public bool stopMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMovement)
        {
            Movement();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void Movement()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        transform.Rotate(0, movX * Time.deltaTime * speedRotate * 0.5f, 0);
        Vector3 movement = transform.forward * movY * speedMovement;
        rb.velocity = movement;
    }

}
