using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensibilidad del mouse
    public Transform playerBody;          // Referencia al objeto del jugador

    private float xRotation = 0f;         // Control de rotación vertical

    void Start()
    {
        // Bloquear el cursor al centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Capturar la entrada del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Control de rotación vertical
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar el ángulo vertical

        // Aplicar las rotaciones
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Vertical
        playerBody.Rotate(Vector3.up * mouseX);                        // Horizontal
    }
}
