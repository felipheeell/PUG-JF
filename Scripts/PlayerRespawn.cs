using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public float limiteDeQueda = -10f;

    private Vector3 pontoRespawn;

    void Start()
    {
        pontoRespawn = transform.position;
    }

    void Update()
    {
        if (transform.position.y < limiteDeQueda)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        // Volta o Player
        transform.position = pontoRespawn;

        // Para o movimento
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        // Faz todas as moedas voltarem
        Coin[] moedas = FindObjectsByType<Coin>(
            FindObjectsInactive.Include,
            FindObjectsSortMode.None
        );

        foreach (Coin moeda in moedas)
        {
            moeda.gameObject.SetActive(true);
        }

        // Zera o contador
        CoinManager manager = FindFirstObjectByType<CoinManager>();

        if (manager != null)
        {
            manager.ReiniciarContador();
        }
    }

    public void TrocarPontoRespawn(Vector3 novoPonto)
    {
        pontoRespawn = novoPonto;
    }
}