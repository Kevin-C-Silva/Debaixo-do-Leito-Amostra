using UnityEngine;

public class seguir : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    public float raycastDistance = 0.5f;
    public LayerMask obstacleLayer;

    private Vector2 randomDirection;
    private float randomMoveTimer;
    private float randomMoveInterval = 1f;

    private Animator anim;
    private SpriteRenderer sr;

    private void Start()
    {
        randomMoveTimer = randomMoveInterval;
        randomDirection = GetRandomDirection();
        
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if ((GameController.IS_JOGADOR_NA_COZINHA && !Object.FindFirstObjectByType<PuzzleMEDO>().JaColetado(Constantes.MARTELO)) ||
            (GameController.IS_JOGADOR_NA_SALA && !Object.FindFirstObjectByType<PuzzleMEDO>().JaColetado(Constantes.ESPELHO)) ||
            (GameController.IS_JOGADOR_NO_QUARTO && !Object.FindFirstObjectByType<PuzzleMEDO>().JaColetado(Constantes.DENTE)) ||
            (GameController.IS_JOGADOR_NA_MASMORRA && !Object.FindFirstObjectByType<PuzzleMEDO>().JaColetado(Constantes.OSSO)) ||
            GameController.IS_PUZZE_RESOLVIDO)
        {
            if (!GameController.IS_FASE_2)
            {
                AndarAleatoriamente();
            }
            else
            {
                SeguirJogador();
            }
        }
        else
        {
            SeguirJogador();
        }

        /*if (target == null) return;

        Vector2 diff = target.position - transform.position;

        Vector2 direction;
        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
        {
            direction = new Vector2(Mathf.Sign(diff.x), 0f); 
        }
        else
        {
            direction = new Vector2(0f, Mathf.Sign(diff.y)); 
        }

        if (Mathf.Abs(direction.x) > 0 && Mathf.Abs(direction.y) > 0)
            direction.y = 0;

        transform.position += (Vector3)(direction * speed * Time.deltaTime);

       
        if (direction.y > 0) 
        {
            anim.Play("andando");
        }
        else if (direction.y < 0) 
        {
            anim.Play("andando");
        }
        else if (direction.x != 0) 
        {
            anim.Play("walk_lado");

            sr.flipX = direction.x < 0;
        }*/
    }

    private void SeguirJogador()
    {
        Vector2 direction = target.position - transform.position;

        float h = Mathf.Abs(direction.x);
        float v = Mathf.Abs(direction.y);

        Vector2 moveDirection = Vector2.zero;

        if (h > v)
        {
            moveDirection = new Vector2(Mathf.Sign(direction.x), 0).normalized;
            if (!CanMove(moveDirection))
            {
                moveDirection = new Vector2(0, Mathf.Sign(direction.y)).normalized;
                if (!CanMove(moveDirection))
                {
                    moveDirection = Vector2.zero;
                }
            }
        }
        else
        {
            moveDirection = new Vector2(0, Mathf.Sign(direction.y)).normalized;
            if (!CanMove(moveDirection))
            {
                moveDirection = new Vector2(Mathf.Sign(direction.x), 0).normalized;
                if (!CanMove(moveDirection))
                {
                    moveDirection = Vector2.zero;
                }
            }
        }

        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);

        animar(moveDirection);
    }

    private void AndarAleatoriamente()
    {
        randomMoveTimer -= Time.deltaTime;
        if (randomMoveTimer <= 0)
        {
            randomDirection = GetRandomDirection();
            randomMoveTimer = randomMoveInterval;
        }

        if (CanMove(randomDirection))
        {
            transform.position += (Vector3)(randomDirection * speed * Time.deltaTime);
        }
        else
        {
            randomDirection = GetRandomDirection();
            randomMoveTimer = randomMoveInterval;
        }

        animar(randomDirection);
    }

    private Vector2 GetRandomDirection()
    {
        int random = Random.Range(0, 4);
        switch (random)
        {
            case 0: return Vector2.up;
            case 1: return Vector2.down;
            case 2: return Vector2.left;
            case 3: return Vector2.right;
            default: return Vector2.zero;
        }
    }

    private bool CanMove(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance, obstacleLayer);
        return hit.collider == null;
    }

    private void animar(Vector2 direction)
    {
        if (direction.y > 0)
        {
            anim.Play("andando");
        }
        else if (direction.y < 0)
        {
            anim.Play("andando");
        }
        else if (direction.x != 0)
        {
            anim.Play("walk_lado");

            sr.flipX = direction.x < 0;
        }
    }
}
