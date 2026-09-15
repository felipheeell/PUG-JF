using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float suavidade = 5f;
    public SpriteRenderer mapa;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    public void TrocarMapa(SpriteRenderer novoMapa)
    {
        mapa = novoMapa;

        // Faz a câmera ir imediatamente para o jogador
        Vector3 posicao = transform.position;
        posicao.x = player.position.x;
        posicao.y = player.position.y;
        transform.position = posicao;
    }

    void LateUpdate()
    {
        if (player == null || mapa == null) return;

        float altura = cam.orthographicSize;
        float largura = altura * cam.aspect;

        float minX = mapa.bounds.min.x + largura;
        float maxX = mapa.bounds.max.x - largura;

        float minY = mapa.bounds.min.y + altura;
        float maxY = mapa.bounds.max.y - altura;

        float x = Mathf.Clamp(player.position.x, minX, maxX);
        float y = Mathf.Clamp(player.position.y, minY, maxY);

        Vector3 novaPosicao = new Vector3(
            x,
            y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            novaPosicao,
            suavidade * Time.deltaTime
        );
    }
}