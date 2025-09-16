using UnityEngine;
using UnityEngine.SceneManagement;

public class finaldojogo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // Para 2D
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("creditor");
        }
    }
}