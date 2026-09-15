using UnityEngine;

public class PortalFinal : MonoBehaviour
{
    public float distancia = 2f;
    public GameObject avisoF;
    public Transform pontoSpawn;

    public CameraFollow cameraFollow;
    public SpriteRenderer mapaDestino;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (avisoF != null)
        {
            avisoF.SetActive(false);
        }
    }

    void Update()
    {
        if (player == null || pontoSpawn == null) return;

        float distanciaDoPlayer = Vector2.Distance(
            player.position,
            transform.position
        );

        bool perto = distanciaDoPlayer <= distancia;

        if (avisoF != null)
        {
            avisoF.SetActive(perto);
        }

        if (perto && Input.GetKeyDown(KeyCode.F))
        {
            // Teleporta o Player para o Mapa 2
            player.position = pontoSpawn.position;

            // Muda o ponto de respawn para o Mapa 2
            PlayerRespawn respawn = player.GetComponent<PlayerRespawn>();

            if (respawn != null)
            {
                respawn.TrocarPontoRespawn(pontoSpawn.position);
            }

            // Troca os limites laterais para os limites do Mapa 2
            PlayerMovement movimento = player.GetComponent<PlayerMovement>();

            if (movimento != null && mapaDestino != null)
            {
                movimento.TrocarLimites(
                    mapaDestino.bounds.min.x,
                    mapaDestino.bounds.max.x
                );
            }

            // Faz a câmera passar a usar os limites do Mapa 2
            if (cameraFollow != null && mapaDestino != null)
            {
                cameraFollow.TrocarMapa(mapaDestino);
            }
        }
    }
}