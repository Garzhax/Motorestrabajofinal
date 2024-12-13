using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float groundCheckDistance = 0.1f; // Distancia para comprobar si está tocando el suelo
    public LayerMask groundLayer; // Capa del suelo
    public float jumpForce = 7f; // Fuerza de salto (puedes ajustarlo)

    private Rigidbody rb;
    private bool isGrounded; // ¿Está tocando el suelo?

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Comprobación si el jugador está tocando el suelo
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        // Obtener las entradas del jugador
        float horizontal = Input.GetAxis("Horizontal"); // Movimiento en el eje X (A/D o flechas)
        float vertical = Input.GetAxis("Vertical"); // Movimiento en el eje Z (W/S o flechas)

        // Crear un vector de movimiento basado en las entradas
        Vector3 moveDirection = (transform.right * horizontal + transform.forward * vertical).normalized;

        // Aplicar movimiento
        MovePlayer(moveDirection);

        // Salto (si el jugador está en el suelo)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    private void MovePlayer(Vector3 direction)
    {
        // Mover el jugador con Rigidbody
        Vector3 targetVelocity = direction * moveSpeed;
        targetVelocity.y = rb.velocity.y; // Mantener la velocidad vertical (para gravedad)
        rb.velocity = targetVelocity;
    }

    private void Jump()
    {
        // Aplicar fuerza de salto si está tocando el suelo
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
