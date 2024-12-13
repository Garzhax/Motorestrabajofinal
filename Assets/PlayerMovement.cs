using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;//elocidad de movimiento

    private void Update()
    {
        // Obtener las entradas del jugador
        float horizontal = Input.GetAxis("Horizontal"); // Movimiento en el eje X (A/D o flechas)
        float vertical = Input.GetAxis("Vertical"); // Movimiento en el eje Z (W/S o flechas)

        // Crear un vector de movimiento basado en las entradas
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        // Mover al jugador en la dirección calculada
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
