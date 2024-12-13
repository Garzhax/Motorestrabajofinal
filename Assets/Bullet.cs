using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 5f;

    void Start()
    {
        // Destruir la bala después de cierto tiempo
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Mover la bala hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Eliminar objetos que colisionen con la bala
        if (other.CompareTag("Enemy") || other.CompareTag("Object"))
        {
            Destroy(other.gameObject); // Destruir el objeto
            Destroy(gameObject);       // Destruir la bala
        }
    }
}
