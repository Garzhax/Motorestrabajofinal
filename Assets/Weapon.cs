using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;   // Prefab de la bala
    public Transform firePoint;       // Punto desde donde se dispara
    public float bulletSpeed = 20f;   // Velocidad de la bala

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Por defecto, "Fire1" es el clic izquierdo del ratón
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Crear la bala en la posición del firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Asegúrate de que la bala tiene un Rigidbody
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * bulletSpeed, ForceMode.VelocityChange); // Empujar la bala hacia adelante
        }
    }
}
