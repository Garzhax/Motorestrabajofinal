using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidad de movimiento
    private Rigidbody rb;         // Componente Rigidbody

    private void Start()
    {
        // Obtener el componente Rigidbody del jugador
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Obtener las entradas del jugador
        float horizontal = Input.GetAxis("Horizontal"); // Movimiento lateral (A/D o flechas)
        float vertical = Input.GetAxis("Vertical");     // Movimiento hacia adelante/atrás (W/S o flechas)

        // Crear un vector de movimiento (dirección)
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        // Aplicar la fuerza de movimiento usando el Rigidbody
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
    }
}
