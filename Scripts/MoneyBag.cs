using UnityEngine;

public class MoneyBag : MonoBehaviour
{
    public int valor = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager manager = FindFirstObjectByType<CoinManager>();

            if (manager != null)
            {
                manager.AdicionarMoeda(valor);
            }

            gameObject.SetActive(false);
        }
    }
}