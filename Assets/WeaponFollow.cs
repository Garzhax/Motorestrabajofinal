using UnityEngine;

public class WeaponFollow : MonoBehaviour
{
    public Transform player;  // Referencia al jugador
    public Vector3 weaponOffset = new Vector3(0.5f, 1f, 0); // Ajusta la posición del arma relativa al jugador

    void Update()
    {
        // Actualiza la posición del arma para que esté pegada al jugador
        if (player != null)
        {
            transform.position = player.position + weaponOffset; // Mueve el arma con el jugador
            transform.rotation = player.rotation; // Opcional: Hace que el arma gire con el jugador
        }
    }
}
