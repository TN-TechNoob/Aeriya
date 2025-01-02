using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intializer : MonoBehaviour
{
    public GameObject playerdataPrefab;


    private void Awake()
    {
        if (FindObjectOfType<playerdata>() == null)
        {
            Instantiate(playerdataPrefab);
        }

     
    }

    void Update()
    {
      
        
    }
}
