using UnityEngine;

public class BlinkSpriteSimple : MonoBehaviour
{
    // Intervalo entre piscadas (em segundos)
    public float blinkInterval = 0.5f;

    // Cor do brilho
    public Color blinkColor = Color.white;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isBlinking = false;
    private float timer = 0f;

    void Start()
    {
        string objectName = gameObject.name;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        bool stopBlinking = false;
        if (gameObject.name == Constantes.GAME_OBJ_BALCAO_COSTA && Object.FindFirstObjectByType<PuzzleMEDO>().JaColetado(Constantes.MARTELO))
        {
            stopBlinking = true;
        }
        else if (gameObject.name == Constantes.GAME_OBJ_ESQUELETO && Object.FindFirstObjectByType<PuzzleMEDO>().JaColetado(Constantes.OSSO))
        {
            stopBlinking = true;
        }
        else if (gameObject.name == Constantes.GAME_OBJ_TAPETE && Object.FindFirstObjectByType<PuzzleMEDO>().JaColetado(Constantes.DENTE))
        {
            stopBlinking = true;
        }
        else if (gameObject.name == Constantes.GAME_OBJ_PIA_2 && ClickHandler.CLICOU_PIA_2)
        {
            stopBlinking = true;
        }
        else if (gameObject.name == Constantes.GAME_OBJ_LIQUIDIFICADOR && ClickHandler.CLICOU_LIQUIDIFICADDOR)
        {
            stopBlinking = true;
        }
        else if (gameObject.name == Constantes.GAME_OBJ_ARMARIOZINHO && ClickHandler.CLICOU_ARMARIOZINHO)
        {
            stopBlinking = true;
        }
        else if (gameObject.name == Constantes.GAME_OBJ_BALCAO_FRENTE_2 && ClickHandler.CLICOU_BALCAO_FRENTE_2)
        {
            stopBlinking = true;
        }
        else if (gameObject.name == Constantes.GAME_OBJ_TAPETE_2 && ClickHandler.CLICOU_TAPETE_2)
        {
            stopBlinking = true;
        }
        else if (gameObject.name == Constantes.GAME_OBJ_ESTANTE && ClickHandler.CLICOU_ESTANTE)
        {
            stopBlinking = true;
        }
        else if (gameObject.name == Constantes.GAME_OBJ_BOOKSHELF && ClickHandler.CLICOU_BOOKESHELF)
        {
            stopBlinking = true;
        }
        else if (gameObject.name == Constantes.GAME_OBJ_PIA_3 && ClickHandler.CLICOU_PIA_3)
        {
            stopBlinking = true;
        }
        else if (gameObject.name == Constantes.GAME_OBJ_ARMARIO && ClickHandler.CLICOU_ARMARIO)
        {
            stopBlinking = true;
        }
        else if (gameObject.name == Constantes.GAME_OBJ_PRIVADA && ClickHandler.CLICOU_PRIVADA)
        {
            stopBlinking = true;
        }
        else if (gameObject.name == Constantes.GAME_OBJ_PRATELEIRA && ClickHandler.CLICOU_PRATELEIRA)
        {
            stopBlinking = true;
        }

        if (stopBlinking)
        {
            spriteRenderer.color = originalColor;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= blinkInterval)
            {
                isBlinking = !isBlinking;
                spriteRenderer.color = isBlinking ? blinkColor : originalColor;
                timer = 0f;
            }
        }
    }
}