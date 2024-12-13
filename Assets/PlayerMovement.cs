using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidad de movimiento
    public float groundDistance = 0.2f; // Distancia para verificar si est� tocando el suelo
    private Rigidbody rb; // Componente Rigidbody
    private bool isGrounded; // Para verificar si el personaje est� tocando el suelo
    private Transform groundCheck; // Para verificar si el personaje est� tocando el suelo

    private void Start()
    {
        // Obtener el componente Rigidbody y el punto para comprobar si est� tocando el suelo
        rb = GetComponent<Rigidbody>();
        groundCheck = transform.Find("GroundCheck"); // Aseg�rate de que tengas un objeto vac�o como GroundCheck
    }

    private void FixedUpdate()
    {
        // Verificar si el personaje est� tocando el suelo
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance);

        // Obtener las entradas del jugador
        float horizontal = Input.GetAxis("Horizontal"); // Movimiento lateral (A/D o flechas)
        float vertical = Input.GetAxis("Vertical");     // Movimiento hacia adelante/atr�s (W/S o flechas)

        // Crear un vector de movimiento (direcci�n)
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        // Aplicar la fuerza de movimiento usando el Rigidbody, manteniendo la gravedad en Y
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
    }
}
