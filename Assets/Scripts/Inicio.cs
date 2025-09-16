using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("VAI SAIR");
            Application.Quit();
        }
    }
}
