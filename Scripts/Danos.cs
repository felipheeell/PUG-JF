using UnityEngine;

public class Danos : MonoBehaviour
{
    void Start()
    {
        foreach (Transform dano in transform)
        {
            Collider2D collider = dano.GetComponent<Collider2D>();

            if (collider == null)
            {
                collider = dano.gameObject.AddComponent<BoxCollider2D>();
            }

            collider.isTrigger = true;

            dano.gameObject.AddComponent<DanoFilho>();
        }
    }
}

public class DanoFilho : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn respawn = other.GetComponent<PlayerRespawn>();

            if (respawn != null)
            {
                respawn.Respawn();
            }
        }
    }
}