using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    public Sprite spriteMartelo;
    public Sprite spriteEspelho;
    public Sprite spriteDente;
    public Sprite spriteOsso;
    public Image[] itemSlots;

    public static bool CLICOU_PIA_2 = false;
    public static bool CLICOU_LIQUIDIFICADDOR = false;
    public static bool CLICOU_ARMARIOZINHO = false;
    public static bool CLICOU_BALCAO_FRENTE_2 = false;
    public static bool CLICOU_TAPETE_2 = false;
    public static bool CLICOU_ESTANTE = false;
    public static bool CLICOU_BOOKESHELF = false;
    public static bool CLICOU_PIA_3 = false;
    public static bool CLICOU_ARMARIO = false;
    public static bool CLICOU_PRIVADA = false;
    public static bool CLICOU_PRATELEIRA = false;

    private GameObject martelo;
    private GameObject osso;
    private GameObject dente;
    private GameObject espelho;
    private GameObject BauAberto;
    private GameObject BauFechado;

    void Start()
    {
        foreach (Image slot in itemSlots)
        {
            if (slot != null)
            {
                slot.enabled = false;
            }
        }

        martelo = GameObject.Find(Constantes.GAME_OBJ_MARTELO);
        martelo.SetActive(false);

        osso = GameObject.Find(Constantes.GAME_OBJ_OSSO);
        osso.SetActive(false);

        dente = GameObject.Find(Constantes.GAME_OBJ_DENTE);
        dente.SetActive(false);

        espelho = GameObject.Find(Constantes.GAME_OBJ_ESPELHO);
        espelho.SetActive(false);

        BauAberto = GameObject.Find(Constantes.GAME_OBJ_BAUABERTO);
        BauAberto.SetActive(false);

        BauFechado = GameObject.Find(Constantes.GAME_OBJ_BAUFECHADO);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Inicio");
            return;
        }

        // Se ocorreu clique esquerdo do mouse
        if (!PuzzleMEDO.PUZZLE_ABERTO && Input.GetMouseButtonDown(0))
        {
            // Recupera a posicao do mouse na tela
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // A partir da posicao do mouse na tela verifica se atingiu algum COLLIDER
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Se atingiu um COLLIDER
            if (hit.collider != null)
            {
                Debug.Log("hit.collider.gameObject.name=" + hit.collider.gameObject.name);

                // Se for um OBJETO piscante vai exibir o OBJETO a ser coletado
                ExibirObjetosNoClick(hit);

                // Se for um OBJETO a ser coletado o OBJETO sera coletado 
                ColetarObjetosNoClick(hit);

                if (GameController.IS_JOGADOR_NA_COZINHA)
                {
                    if (hit.collider.gameObject.name == Constantes.GAME_OBJ_PIA_2)
                    {
                        CLICOU_PIA_2 = true;
                    }
                    else if (hit.collider.gameObject.name == Constantes.GAME_OBJ_LIQUIDIFICADOR)
                    {
                        CLICOU_LIQUIDIFICADDOR = true;
                    }
                    else if (hit.collider.gameObject.name == Constantes.GAME_OBJ_ARMARIOZINHO)
                    {
                        CLICOU_ARMARIOZINHO = true;
                    }
                }

                if (GameController.IS_JOGADOR_NA_SALA)
                {
                    if (hit.collider.gameObject.name == Constantes.GAME_OBJ_BALCAO_FRENTE_2)
                    {
                        CLICOU_BALCAO_FRENTE_2 = true;
                    }
                    else if (hit.collider.gameObject.name == Constantes.GAME_OBJ_TAPETE_2)
                    {
                        CLICOU_TAPETE_2 = true;
                    }
                    else if (hit.collider.gameObject.name == Constantes.GAME_OBJ_ESTANTE)
                    {
                        CLICOU_ESTANTE = true;
                    }
                    else if (hit.collider.gameObject.name == Constantes.GAME_OBJ_BOOKSHELF)
                    {
                        CLICOU_BOOKESHELF = true;
                    }
                }

                if (GameController.IS_JOGADOR_NO_QUARTO)
                {
                    if (hit.collider.gameObject.name == Constantes.GAME_OBJ_PIA_3)
                    {
                        CLICOU_PIA_3 = true;
                    }
                    else if (hit.collider.gameObject.name == Constantes.GAME_OBJ_ARMARIO)
                    {
                        CLICOU_ARMARIO = true;
                    }
                    else if (hit.collider.gameObject.name == Constantes.GAME_OBJ_PRIVADA)
                    {
                        CLICOU_PRIVADA = true;
                    }
                }

                if (GameController.IS_JOGADOR_NA_MASMORRA)
                {
                    if (hit.collider.gameObject.name == Constantes.GAME_OBJ_PRATELEIRA)
                    {
                        CLICOU_PRATELEIRA = true;
                    }
                }
            }
        }
    }

    void ExibirObjetosNoClick(RaycastHit2D hit)
    {
        // Se for um OBJETO piscante vai exibir o OBJETO a ser coletado
        if (hit.collider.gameObject.name == Constantes.GAME_OBJ_BALCAO_COSTA && GameController.IS_JOGADOR_NA_COZINHA)
        {
            Debug.Log("Constantes.GAME_OBJ_BALCAO_COSTA");

            // Se o OBJETO ainda nao foi coletado aparecera na tela
            if (!Object.FindFirstObjectByType<PuzzleMEDO>().JaColetado(Constantes.MARTELO))
            {
                Debug.Log("Constantes.GAME_OBJ_BALCAO_COSTA Ativar MARTELO");
                martelo.SetActive(true);
            }
        }
        // Se for um OBJETO piscante vai exibir o OBJETO a ser coletado
        else if (hit.collider.gameObject.name == Constantes.GAME_OBJ_ESQUELETO && GameController.IS_JOGADOR_NA_MASMORRA)
        {
            Debug.Log("Constantes.GAME_OBJ_ESQUELETO");

            // Se o OBJETO ainda nao foi coletado aparecera na tela
            if (!Object.FindFirstObjectByType<PuzzleMEDO>().JaColetado(Constantes.OSSO))
            {
                Debug.Log("Constantes.GAME_OBJ_ESQUELETO Ativar OSSO");
                osso.SetActive(true);
            }
        }

        else if (hit.collider.gameObject.name == Constantes.GAME_OBJ_TAPETE && GameController.IS_JOGADOR_NO_QUARTO)
        {
            Debug.Log("Constantes.GAME_OBJ_TAPETE");

            if (!Object.FindFirstObjectByType<PuzzleMEDO>().JaColetado(Constantes.DENTE))
            {
                Debug.Log("Constantes.GAME_OBJ_TAPETE Ativar DENTE");
                dente.SetActive(true);
            }
        }

        else if (hit.collider.gameObject.name == Constantes.GAME_OBJ_BAUFECHADO && GameController.IS_JOGADOR_NA_SALA)
        {
            Debug.Log("Consntantes.GAME_OBJ_BAUFECHADO");

            if (!Object.FindFirstObjectByType<PuzzleMEDO>().JaColetado(Constantes.ESPELHO))
            {
                Debug.Log("Constantes.GAME_OBJ_BAUFECHADO Ativar ESPELHO");
                espelho.SetActive(true);
                BauAberto.SetActive(true);
                BauFechado.SetActive(false);
            }
        }
    }

    void ColetarObjetosNoClick(RaycastHit2D hit)
    {
        // Se for um OBJETO a ser coletado o OBJETO sera coletado 
        if (hit.collider.gameObject.name == Constantes.GAME_OBJ_MARTELO && GameController.IS_JOGADOR_NA_COZINHA)
        {
            Debug.Log("Constantes.GAME_OBJ_MARTELO");

            // Se o OBJETO ainda nao foi coletado sera coletado
            if (!Object.FindFirstObjectByType<PuzzleMEDO>().JaColetado(Constantes.MARTELO))
            {
                Debug.Log("Constantes.GAME_OBJ_MARTELO Coletar MARTELO");
                ColetarObjeto(Constantes.MARTELO, martelo);
            }
        }
        else if (hit.collider.gameObject.name == Constantes.GAME_OBJ_OSSO && GameController.IS_JOGADOR_NA_MASMORRA)
        {
            Debug.Log("Constantes.GAME_OBJ_OSSO");

            // Se o OBJETO ainda nao foi coletado sera coletado
            if (!Object.FindFirstObjectByType<PuzzleMEDO>().JaColetado(Constantes.OSSO))
            {
                Debug.Log("Constantes.GAME_OBJ_OSSO Coletar OSSO");
                ColetarObjeto(Constantes.OSSO, osso);
            }
        }
        else if (hit.collider.gameObject.name == Constantes.GAME_OBJ_DENTE && GameController.IS_JOGADOR_NO_QUARTO)
        {
            Debug.Log("Constantes.GAME_OBJ_DENTE");

            if (!Object.FindFirstObjectByType<PuzzleMEDO>().JaColetado(Constantes.DENTE))
            {
                Debug.Log("Constantes.GAME_OBJ_DENTE Coletar DENTE");
                ColetarObjeto(Constantes.DENTE, dente);
            }
        }
        else if (hit.collider.gameObject.name == Constantes.GAME_OBJ_ESPELHO && GameController.IS_JOGADOR_NA_SALA)
        {
            Debug.Log("Constantes.GAME_OBJ_ESPELHO");

            if (!Object.FindFirstObjectByType<PuzzleMEDO>().JaColetado(Constantes.ESPELHO))
            {
                Debug.Log("Constantes.GAME_OBJ_ESPELHO Coletar ESPELHO");
                ColetarObjeto(Constantes.ESPELHO, espelho);
            }
        }
    }

    void ColetarObjeto(string nomeObjeto, GameObject objeto)
    {
        Object.FindFirstObjectByType<seguir>().speed += 0.2f; 

        // Coleta
        Object.FindFirstObjectByType<PuzzleMEDO>().ColetarObjeto(nomeObjeto);

        // Exibe na console que coletou
        Debug.Log(nomeObjeto + " coletado!");

        // Apaga o objeto do cenario
        Destroy(objeto);

        if (nomeObjeto == Constantes.MARTELO)
        {
            itemSlots[0].sprite = spriteMartelo;
            itemSlots[0].enabled = true;
        }
        if (nomeObjeto == Constantes.ESPELHO)
        {
            itemSlots[1].sprite = spriteEspelho;
            itemSlots[1].enabled = true;
        }
        if (nomeObjeto == Constantes.DENTE)
        {
            itemSlots[2].sprite = spriteDente;
            itemSlots[2].enabled = true;
        }
        if (nomeObjeto == Constantes.OSSO)
        {
            itemSlots[3].sprite = spriteOsso;
            itemSlots[3].enabled = true;
        }
    }
}