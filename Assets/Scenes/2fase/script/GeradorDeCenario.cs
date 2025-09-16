using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeradorDeCenarioTras : MonoBehaviour
{
    [Header("Configuração do Cenário")]
    public GameObject[] blocosCenario;   
    public GameObject finalCaminho;      
    public float tamanhoTile = 10f;      
    public int tilesVisiveis = 6;        
    public int maxTilesAntesDoFinal = 10; 

    [Header("Configuração de Obstáculos")]
    public GameObject[] obstaculos;      
    public float chanceObstaculo = 0.3f;  
    public float[] lanes = { -2f, 0f, 2f }; 

    private Transform player;
    private float zSpawn;
    private Queue<GameObject> tilesAtivos = new Queue<GameObject>();
    private int tilesGerados = 0;
    private bool gerouFinal = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        zSpawn = player.position.y;

       
        for (int i = 0; i < tilesVisiveis; i++)
        {
            if (i < tilesVisiveis - 1)
                SpawnTile();
            else
                SpawnTileFinal();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Inicio");
            return;
        }

        if (!gerouFinal)
        {
            
            if (player.position.y < zSpawn + tamanhoTile)
            {
                if (tilesGerados < maxTilesAntesDoFinal)
                    SpawnTile();
                else
                    SpawnTileFinal();

                RemoverTile();
            }
        }
    }

    void SpawnTile()
    {
        
        int index = Random.Range(0, blocosCenario.Length);
        GameObject tile = Instantiate(blocosCenario[index],
            new Vector3(0, zSpawn, 0),
            Quaternion.identity);

        tilesAtivos.Enqueue(tile);

       
        if (obstaculos.Length > 0 && Random.value < chanceObstaculo)
        {
            float x = lanes[Random.Range(0, lanes.Length)];
            float y = zSpawn + Random.Range(-tamanhoTile / 2f, tamanhoTile / 2f);

            Vector3 pos = new Vector3(x, y, 0);
            int obsIndex = Random.Range(0, obstaculos.Length);
            Instantiate(obstaculos[obsIndex], pos, Quaternion.identity, tile.transform);
        }

        zSpawn -= tamanhoTile;
        tilesGerados++;
    }

    void SpawnTileFinal()
    {
        GameObject tileFinal = Instantiate(finalCaminho,
            new Vector3(0, zSpawn, 0),
            Quaternion.identity);

        tilesAtivos.Enqueue(tileFinal);
        zSpawn -= tamanhoTile;
        gerouFinal = true;
    }

    void RemoverTile()
    {
        //GameObject tileRemovido = tilesAtivos.Dequeue();
        //Destroy(tileRemovido);

        if (tilesAtivos.Count > 0)
        {
            GameObject tileRemovido = tilesAtivos.Peek();
            if (tileRemovido != finalCaminho)
            {
                tilesAtivos.Dequeue();
                Destroy(tileRemovido);
                Debug.Log("Tile removido.");
            }
            else
            {
                Debug.Log("Tentativa de remover finalCaminho bloqueada.");
            }
        }
    }
}
