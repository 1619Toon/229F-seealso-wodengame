using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (CoinCounter.instance != null)
            {
                CoinCounter.instance.IncreaseCoins(value);
            }
            else
            {
                Debug.LogWarning("CoinCounter instance is missing!");
            }
        }
    }
}
