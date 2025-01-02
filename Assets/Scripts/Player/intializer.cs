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
            Debug.LogError("PlayerHealth 物件未找到！");
        }
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (playerHealth != null)
            {
                playerHealth.AddHealth(20); 
                Debug.Log("觸發了 J 鍵！");
            }
            else
            {
                Debug.LogError("PlayerHealth 尚未初始化！");
            }
        }
    }
}
