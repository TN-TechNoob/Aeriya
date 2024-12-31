using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdata : MonoBehaviour
{
  
    public int coin = 1000; 
    public int potionCount = 1;



    private static playerdata instance;

    private void Awake()
    {
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
