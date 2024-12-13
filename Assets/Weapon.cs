using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint; // Punto de disparo en el arma
    public float bulletSpeed = 20f; // Velocidad de la bala
    private bool isShooting = false; // Estado para evitar que dispare varias veces de forma no deseada

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting) // Disparo con el clic izquierdo
        {
            Debug.Log("Disparo activado"); // Esto debería aparecer en la consola cuando dispares
            Shoot(); // Llama a la función de disparo
            isShooting = true; // Bloquea el disparo hasta que el siguiente clic se registre
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            // Permite disparar nuevamente cuando el jugador suelta el botón de disparo
            isShooting = false;
        }
    }

    void Shoot()
    {
        if (firePoint == null || bulletPrefab == null)
        {
            Debug.LogWarning("FirePoint o BulletPrefab no está asignado.");
            return;
        }

        Debug.Log("Instanciando bala...");
        // Instanciar la bala en el punto de disparo con la misma rotación
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Aplicar velocidad a la bala
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed; // Mueve la bala hacia adelante
        }
    }
}
