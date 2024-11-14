using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    private TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCoinCount(CoinCollect coinCollect)
    {
        coinText.text = coinCollect.NumberOfCoins.ToString();
    }
}
