using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool IS_JOGADOR_NA_COZINHA = false;
    public static bool IS_JOGADOR_NA_SALA = false;
    public static bool IS_JOGADOR_NO_QUARTO = false;
    public static bool IS_JOGADOR_NA_MASMORRA = false;
    public static bool IS_PUZZE_RESOLVIDO = false;
    public static bool IS_FASE_2 = false;

    public GameObject painelPause;
    
    private bool pausado = false;

    public void CarregarCenaPorNome(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void PausarOuDespausar()
    {
        pausado = !pausado;

        if (pausado)
        {
            Time.timeScale = 0f; // pausa
            //painelPause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f; // despausa
            //painelPause.SetActive(true);
        }
    }

    public void FecharJogo()
    {
        Application.Quit();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //painelPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            PausarOuDespausar();
        }
    }
}
