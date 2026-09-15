using UnityEngine;

public class SetupCoins : MonoBehaviour
{
    void Start()
    {
        foreach (Transform moeda in transform)
        {
            if (moeda.GetComponent<Collider2D>() == null)
            {
                CircleCollider2D collider = moeda.gameObject.AddComponent<CircleCollider2D>();
                collider.isTrigger = true;
            }

            if (moeda.GetComponent<Coin>() == null)
            {
                moeda.gameObject.AddComponent<Coin>();
            }
        }
    }
}