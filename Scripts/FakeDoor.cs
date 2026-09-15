using UnityEngine;

public class FakeDoor : MonoBehaviour
{
    public float distancia = 2f;
    public GameObject avisoF;

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
        if (player == null) return;

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
            PlayerRespawn respawn = player.GetComponent<PlayerRespawn>();

            if (respawn != null)
            {
                respawn.Respawn();
            }
        }
    }
}