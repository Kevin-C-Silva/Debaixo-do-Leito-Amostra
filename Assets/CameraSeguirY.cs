using UnityEngine;

public class CameraSeguirY : MonoBehaviour
{
    public Transform alvo;   // Objeto que a câmera vai seguir
    public float suavidade = 5f; // Quanto maior, mais suave o movimento

    private float xFixo;     // Guardar posição fixa do X
    private float zFixo;     // Guardar posição fixa do Z

    void Start()
    {
        // Pega a posição inicial da câmera no X e Z
        xFixo = transform.position.x;
        zFixo = transform.position.z;
    }

    void LateUpdate()
    {
        if (alvo == null) return;

        // Posição alvo: fixa X e Z, segue só o Y do player
        Vector3 posDesejada = new Vector3(xFixo, alvo.position.y, zFixo);

        // Suaviza o movimento
        transform.position = Vector3.Lerp(transform.position, posDesejada, suavidade * Time.deltaTime);
    }
}
