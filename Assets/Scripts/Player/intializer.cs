using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intializer : MonoBehaviour
{
    public GameObject playerdataPrefab;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        if (FindObjectOfType<playerdata>() == null)
        {
            Instantiate(playerdataPrefab);
        }

       
        playerHealth = FindObjectOfType<PlayerHealth>();

        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth ���󥼧��I");
        }
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (playerHealth != null)
            {
                playerHealth.AddHealth(20); 
                Debug.Log("Ĳ�o�F J ��I");
            }
            else
            {
                Debug.LogError("PlayerHealth �|����l�ơI");
            }
        }
    }
}
