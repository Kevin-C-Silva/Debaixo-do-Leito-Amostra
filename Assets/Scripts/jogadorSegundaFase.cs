using UnityEngine;

public class JogadorLane : MonoBehaviour
{
    [Header("Configura��o de Movimento")]
    public float velocidade = 5f;          // Velocidade pra baixo
    public float trocaVelocidade = 10f;    // Velocidade de troca entre lanes
    public float[] lanes = { -2f, 0f, 2f }; // Posi��es poss�veis no eixo X

    private int laneAtual = 1;             // Come�a no meio (index 1)
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Come�a na lane inicial
        Vector2 pos = rb.position;
        pos.x = lanes[laneAtual];
        rb.position = pos;

        // For�a anima��o pra baixo
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", -1);
        animator.SetBool("Andando", true);
    }

    void Update()
    {
        // Input para trocar de lane
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (laneAtual > 0) laneAtual--;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (laneAtual < lanes.Length - 1) laneAtual++;
        }
    }

    void FixedUpdate()
    {
        // Movimento autom�tico para baixo
        Vector2 moveDown = Vector2.down * velocidade * Time.fixedDeltaTime;

        // Movimento suave at� a lane desejada
        float targetX = lanes[laneAtual];
        float newX = Mathf.MoveTowards(rb.position.x, targetX, trocaVelocidade * Time.fixedDeltaTime);

        // Aplica movimento
        rb.MovePosition(new Vector2(newX, rb.position.y) + moveDown);
    }
}
