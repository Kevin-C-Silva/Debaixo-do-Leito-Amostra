using UnityEngine;

public class CameraSeguirY : MonoBehaviour
{
    public Transform alvo;   // Objeto que a c�mera vai seguir
    public float suavidade = 5f; // Quanto maior, mais suave o movimento

    private float xFixo;     // Guardar posi��o fixa do X
    private float zFixo;     // Guardar posi��o fixa do Z

    void Start()
    {
        // Pega a posi��o inicial da c�mera no X e Z
        xFixo = transform.position.x;
        zFixo = transform.position.z;
    }

    void LateUpdate()
    {
        if (alvo == null) return;

        // Posi��o alvo: fixa X e Z, segue s� o Y do player
        Vector3 posDesejada = new Vector3(xFixo, alvo.position.y, zFixo);

        // Suaviza o movimento
        transform.position = Vector3.Lerp(transform.position, posDesejada, suavidade * Time.deltaTime);
    }
}
