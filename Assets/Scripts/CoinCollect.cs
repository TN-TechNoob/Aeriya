using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinCollect : MonoBehaviour
{
    public int NumberOfCoins { get; private set; }

    public UnityEvent<CoinCollect> OnCoinCollected;

    public void CoinCollected()
    {
        NumberOfCoins++;
        OnCoinCollected.Invoke(this);
    }
}
