using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int _coinsCollected = 0;

    [SerializeField] private Text cointsText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            _coinsCollected ++;
            Debug.Log($"Coins: {_coinsCollected}");
            cointsText.text = "Coins: " + _coinsCollected;
        }
    }

}
