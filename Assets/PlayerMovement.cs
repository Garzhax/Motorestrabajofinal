using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidad de movimiento
    public float groundDistance = 0.2f; // Distancia para verificar si est� tocando el suelo
    private Rigidbody rb; // Componente Rigidbody
    private bool isGrounded; // Para verificar si el personaje est� tocando el suelo
    public Transform groundCheck; // Para verificar si el personaje est� tocando el suelo

    private void Start()
    {
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();

        // Verificar si groundCheck est� asignado
        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck no est� asignado. Por favor, asigna un Transform en el Inspector.");
        }
    }

    private void FixedUpdate()
    {
        // Verificar si el personaje est� tocando el suelo solo si groundCheck no es null
        if (groundCheck != null)
        {
            isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance);
        }

        // Obtener las entradas del jugador
        float horizontal = Input.GetAxis("Horizontal"); // Movimiento lateral (A/D o flechas)
        float vertical = Input.GetAxis("Vertical");     // Movimiento hacia adelante/atr�s (W/S o flechas)

        // Crear un vector de movimiento (direcci�n)
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        // Mover al jugador solo en los ejes X y Z, manteniendo la componente Y para la gravedad
        if (isGrounded) // Solo mover si el personaje est� tocando el suelo
        {
            Vector3 targetVelocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
            rb.velocity = targetVelocity;
        }
    }
}
