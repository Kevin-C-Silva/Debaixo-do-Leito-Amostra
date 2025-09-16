using UnityEngine;

public class CaixaDestrutivel : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Respawn"))
        {
            Destroy(gameObject); // Destroi a caixa
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Respawn"))
        {
            Destroy(gameObject); // Destroi a caixa
        }
    }
}
