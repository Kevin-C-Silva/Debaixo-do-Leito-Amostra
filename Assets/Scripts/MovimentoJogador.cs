using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimentoJogador : MonoBehaviour
{
    public float velocidade = 5f;
    private Vector2 direcao;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Se horizontal e vertical for maior que 0 significa que esta indo na diagonal
        // nesse caso vai ignorar a vertical e ir para horizontal
        if (Mathf.Abs(h) > 0 && Mathf.Abs(v) > 0)
            v = 0;

        direcao = new Vector2(h, v).normalized;

        animator.SetFloat("Horizontal", h);

        if (v > 0)
            animator.SetFloat("Vertical", 1);
        else if (v < 0)
            animator.SetFloat("Vertical", -1);
        else
            animator.SetFloat("Vertical", 0);

        animator.SetBool("Andando", direcao != Vector2.zero);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direcao * velocidade * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Cozinha")
            GameController.IS_JOGADOR_NA_COZINHA = true;
        if (other.name == "Sala")
            GameController.IS_JOGADOR_NA_SALA = true;
        if (other.name == "Quarto")
            GameController.IS_JOGADOR_NO_QUARTO = true;
        if (other.name == "Masmorra")
            GameController.IS_JOGADOR_NA_MASMORRA = true;

        if (other.name == "zé do caixao")
            SceneManager.LoadScene("Inicio");

        if (other.name == "portaaberta_0")
        {
            GameController.IS_FASE_2 = true;
            SceneManager.LoadScene("segunda fase");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Cozinha")
            GameController.IS_JOGADOR_NA_COZINHA = false;
        if (other.name == "Sala")
            GameController.IS_JOGADOR_NA_SALA = false;
        if (other.name == "Quarto")
            GameController.IS_JOGADOR_NO_QUARTO = false;
        if (other.name == "Masmorra")
            GameController.IS_JOGADOR_NA_MASMORRA = false;
    }
}