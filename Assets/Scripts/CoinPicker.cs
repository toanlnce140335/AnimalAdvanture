using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPicker : MonoBehaviour
{
    public int coin = 0;
    public int Coin { get { return coin; } }

    public TextMeshProUGUI textCoins;

    private void Start()
    {
        textCoins.text = "0";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "coin")
        {
            coin++;
            textCoins.text = coin.ToString();
            Destroy(collision.gameObject);
        }

    }
}
