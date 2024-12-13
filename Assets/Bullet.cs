using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyAfter = 5f; // Tiempo antes de destruir la bala si no impacta nada

    void Start()
    {
        // Destruir la bala después de un tiempo para evitar que siga existiendo indefinidamente
        Destroy(gameObject, destroyAfter);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si la bala impacta un objeto con la etiqueta "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Destruir al enemigo
            Destroy(other.gameObject);

            // Destruir la bala
            Destroy(gameObject);
        }
    }
}
