using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intializer : MonoBehaviour
{
    public GameObject playerdataPrefab;
    private PlayerHealth playerHealth;

    private int HealUseCount = 0;
    private const int MaxHealCount = 10;

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
            if (HealUseCount >= MaxHealCount)
            {
                Debug.Log("你已經用完所有的藥水了！不能再增加血量。");
                return;
            }
            if (playerHealth != null)
            {
                playerHealth.AddHealth(20);
                HealUseCount++;
                Debug.Log("觸發了 J 鍵！");
            }
            else
            {
                Debug.LogError("PlayerHealth 尚未初始化！");
            }
        }
    }
}
