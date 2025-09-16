using UnityEngine;

public class TileFinalTrigger : MonoBehaviour
{
    public string scriptAutoRun = "PlayerRunner";   // nome do script de correr automático
    public string scriptMovimento = "PlayerController"; // nome do script de movimento manual

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Pega todos os scripts no player
            MonoBehaviour autoRun = other.GetComponent(scriptAutoRun) as MonoBehaviour;
            MonoBehaviour movimento = other.GetComponent(scriptMovimento) as MonoBehaviour;

            // Desativa auto-run
            if (autoRun != null)
                autoRun.enabled = false;

            // Ativa controle manual
            if (movimento != null)
                movimento.enabled = true;
        }
    }
}
