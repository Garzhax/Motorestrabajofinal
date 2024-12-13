using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint;    // Punto de disparo
    public float fireRate = 0.5f;  // Cadencia de disparo
    private float nextFireTime = 0f;

    void Update()
    {
        // Detectar disparo al presionar clic izquierdo
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Instanciar la bala en el punto de disparo
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

