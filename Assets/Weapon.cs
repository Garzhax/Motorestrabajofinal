using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint; // Punto de disparo en el arma
    public float bulletSpeed = 20f; // Velocidad de la bala

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Disparo con clic izquierdo o control configurado
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (firePoint == null || bulletPrefab == null)
        {
            Debug.LogWarning("FirePoint o BulletPrefab no está asignado.");
            return;
        }

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
