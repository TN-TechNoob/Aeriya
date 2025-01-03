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
            Debug.LogError("PlayerHealth ���󥼧��I");
        }
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (HealUseCount >= MaxHealCount)
            {
                Debug.Log("�A�w�g�Χ��Ҧ����Ĥ��F�I����A�W�[��q�C");
                return;
            }
            if (playerHealth != null)
            {
                playerHealth.AddHealth(20);
                HealUseCount++;
                Debug.Log("Ĳ�o�F J ��I");
            }
            else
            {
                Debug.LogError("PlayerHealth �|����l�ơI");
            }
        }
    }
}
