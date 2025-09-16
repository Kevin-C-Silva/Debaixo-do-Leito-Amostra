using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class PuzzleMEDO : MonoBehaviour
{
    public static bool PUZZLE_ABERTO = false;

    [Header("Referencias")]
    public TMP_InputField[] letras;
    public GameObject telaPuzzle;
    public GameObject recompensa;

    private bool temEspelho = false;
    private bool temMartelo = false;
    private bool temOsso = false;
    private bool temDente = false;

    private int inputFieldIndex = 0;

    void Start()
    {
        telaPuzzle.SetActive(false);
        recompensa.SetActive(false);

        foreach (TMP_InputField campo in letras)
        {
            campo.characterLimit = 1;
            campo.onValueChanged.AddListener(delegate {
                //campo.text = campo.text.ToUpper();
                campo.caretPosition = campo.text.Length;
            });
        }
    }

    private void Update()
    {
        if (PUZZLE_ABERTO)
        {
            if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                inputFieldIndex++;
                if (inputFieldIndex > 3)
                {
                    inputFieldIndex = 0;
                }
                FocarCaixaDeTexto();
            }
        }
    }

    public void ColetarObjeto(string nomeObjeto)
    {
        if (nomeObjeto.ToLower() == Constantes.ESPELHO.ToLower())
            temEspelho = true;
        else if (nomeObjeto.ToLower() == Constantes.MARTELO.ToLower())
            temMartelo = true;
        else if (nomeObjeto.ToLower() == Constantes.OSSO.ToLower())
            temOsso = true;
        else if (nomeObjeto.ToLower() == Constantes.DENTE.ToLower())
            temDente = true;
    }

    public bool JaColetado(string nomeObjeto)
    {
        if (nomeObjeto.ToLower() == Constantes.ESPELHO.ToLower())
            return temEspelho;
        else if (nomeObjeto.ToLower() == Constantes.MARTELO.ToLower())
            return temMartelo;
        else if (nomeObjeto.ToLower() == Constantes.OSSO.ToLower())
            return temOsso;
        else if (nomeObjeto.ToLower() == Constantes.DENTE.ToLower())
            return temDente;
        else
            return false;
    }

    public bool ColetouTudo()
    {
        //return temEspelho && temMartelo && temOsso && temDente;
        return true;
    }

    public void AbrirPuzzle()
    {
        if (ColetouTudo())
        {
            Debug.Log("Vai abrir o puzzle");

            PUZZLE_ABERTO = true;
            telaPuzzle.SetActive(true);
            Time.timeScale = 0f;

            inputFieldIndex = 0;
            FocarCaixaDeTexto();
        }
        else
        {
            Debug.Log("Ainda faltam objetos para abrir o puzzle!");
        }
    }

    private void FocarCaixaDeTexto()
    {
        letras[inputFieldIndex].Select();
        //letras[inputFieldIndex].ActivateInputField();
    }

    public void VerificarResposta()
    {
        Debug.Log("VerificarResposta");

        string resposta = "";

        foreach (TMP_InputField campo in letras)
        {
            resposta += campo.text.ToUpper();
        }

        if (resposta == "MEDO")
        {
            GameController.IS_PUZZE_RESOLVIDO = true;
            Debug.Log("Puzzle Resolvido!");
            recompensa.SetActive(true);
            FecharPuzzle();
        }
        else
        {
            Debug.Log("Resposta incorreta!");
            foreach (TMP_InputField campo in letras)
            {
                campo.text = "";
            }

            inputFieldIndex = 0;
            FocarCaixaDeTexto();
        }
    }

    public void FecharPuzzle()
    {
        PUZZLE_ABERTO = false;
        telaPuzzle.SetActive(false);
        Time.timeScale = 1f;
    }
}
