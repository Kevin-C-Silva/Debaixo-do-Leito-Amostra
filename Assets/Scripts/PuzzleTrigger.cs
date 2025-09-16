using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    private bool dentroDoPuzzle = false;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dentroDoPuzzle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dentroDoPuzzle = false;
        }
    }

    private void Update()
    {
        if (dentroDoPuzzle && !PuzzleMEDO.PUZZLE_ABERTO && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Clicou E");
            Object.FindFirstObjectByType<PuzzleMEDO>().AbrirPuzzle();
        }
    }
}