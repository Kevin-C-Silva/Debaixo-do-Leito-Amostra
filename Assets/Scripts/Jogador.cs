using UnityEngine;

public class Jogador : MonoBehaviour
{
    Vector2 jogador;

    void Start()
    {
        jogador = new Vector2(0f, 0f);
        transform.position = jogador;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PuzzleMEDO.PUZZLE_ABERTO)
        {
            Mover();
        }
    }

    void Mover()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            jogador.y = 0.05f;
            jogador.x = 0f;
            transform.Translate(jogador);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            jogador.x = -0.05f;
            jogador.y = 0f;
            transform.Translate(jogador);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            jogador.y = -0.05f;
            jogador.x = 0f;
            transform.Translate(jogador);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            jogador.x = 0.05f;
            jogador.y = 0f;
            transform.Translate(jogador);
        }       
        
    }
}
