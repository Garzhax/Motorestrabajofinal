using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidad de movimiento
    public float groundDistance = 0.2f; // Distancia para verificar si está tocando el suelo
    private Rigidbody rb; // Componente Rigidbody
    private bool isGrounded; // Para verificar si el personaje está tocando el suelo
    private Transform groundCheck; // Para verificar si el personaje está tocando el suelo

    private void Start()
    {
        // Obtener el componente Rigidbody y el punto para comprobar si está tocando el suelo
        rb = GetComponent<Rigidbody>();
        groundCheck = transform.Find("GroundCheck"); // Asegúrate de que tengas un objeto vacío como GroundCheck
    }

    private void FixedUpdate()
    {
        // Verificar si el personaje está tocando el suelo
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance);

        // Obtener las entradas del jugador
        float horizontal = Input.GetAxis("Horizontal"); // Movimiento lateral (A/D o flechas)
        float vertical = Input.GetAxis("Vertical");     // Movimiento hacia adelante/atrás (W/S o flechas)

        // Crear un vector de movimiento (dirección)
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        // Aplicar la fuerza de movimiento usando el Rigidbody, manteniendo la gravedad en Y
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
    }
}
