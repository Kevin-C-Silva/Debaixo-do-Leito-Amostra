using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class ColisaoRespawn : MonoBehaviour
{
    [Header("UI")]
    public Image telaDeAviso; 
    public float tempoExibicao = 3f;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "tile chao de madeira_0")
        {
            Debug.Log(collision.name);
            SceneManager.LoadScene("creditor");
        }

        if (collision.CompareTag("Respawn"))
        {
            StartCoroutine(MostrarImagemERestartar());
        }
    }

    private IEnumerator MostrarImagemERestartar()
    {
        if (telaDeAviso != null)
            telaDeAviso.gameObject.SetActive(true);

        yield return new WaitForSeconds(tempoExibicao);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
