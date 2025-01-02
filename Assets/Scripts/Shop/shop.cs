using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class shop : MonoBehaviour
{
   public GameObject ShopPanel;
    private bool nearby=false;

    //public Text count;
    private int counter;
    public Text potionCountText;
    public Image stamina;
    public Image source;
    public Image death;
    int potionCount = 0;

    private playerdata playerdata;

    private PlayerHealth playerHealth;


    //public GameObject coinprefab;
    void Awake()
    {
       // DontDestroyOnLoad(gameObject);
    }
    public int coin = 1000; //FOR TEST

    // Start is called before the first frame update
    void Start()
    {
        if (ShopPanel != null)
        {
            ShopPanel.SetActive(false);
        }

        playerdata = FindObjectOfType<playerdata>();
        playerHealth = FindObjectOfType<PlayerHealth>();

        if (playerdata == null)
        {
            Debug.LogError("playerdata 未找到！");
        }

        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth 未找到！");
        }

        potionCount = playerdata.potionCount;
        UpdateUI();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            nearby = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            nearby = false;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (nearby && Input.GetKeyDown(KeyCode.P))
        {
            ShopPanel.SetActive(true);
        }

        if (playerHealth != null && Input.GetKeyDown(KeyCode.J) && !EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("按下 J 鍵，觸發藥水使用");
            Restoration_Potion();
        }
    }

    private void UpdateUI()
    {
    
        if (potionCountText != null)
        {
            potionCountText.text = playerdata.potionCount.ToString();
        }

    }
    public void Restoration_Potion()
    {
        if (potionCount > 0 && playerHealth != null)
        {
            potionCount--;
            playerHealth.AddHealth(6);
            playerdata.potionCount = potionCount;
            UpdateUI();

          
        }
        else
        {
            Debug.Log("沒有足夠的藥水！");
        }
    }
    public void Buy_Restoration_Potion()
    {
       

        int cost = 50;
        if (coin >= cost)
        {
            coin -= cost;
            potionCount++;
            playerdata.potionCount = potionCount;
            UpdateUI();
            Debug.Log("購買成功！");
        }
        else
        {
            Debug.Log("金幣不足！");
        }
    }
    //private IEnumerator Stamina_Charm()
    //{
      //  while (true)                    
       // {
          //  yield return new WaitForSeconds(5);
           // playerHealth.AddStrength(2); 
       // }
   // }
    public void Buy_stamina_charm()
    {
        stamina.color = Color.white;
        int cost = 300;
        if (coin >= cost)
        {   
            coin -= cost;
            //Stamina_Charm();
            Debug.Log("購買成功！");
        }
        else
        {
            Debug.Log("金幣不足！");
        }
    }
    private IEnumerator Source_Of_Life()
    {
        while (true)
        {
            yield return new WaitForSeconds(10); 
            playerHealth.AddHealth(1);
        }
    }
    public void Buy_Source_Of_Life()
    {
        source.color = Color.white;
        int cost = 300;
        if (coin >= cost)
        {
            coin -= cost;
            Source_Of_Life();
            Debug.Log("購買成功！");
        }
        else
        {
            Debug.Log("金幣不足！");
        }

    }
    public void Death_Free_Gold_Medal()
    {
         if (playerHealth != null && playerHealth.isDead)
        {
           playerHealth.Revive();
          

        }
    }
    public void Buy_Death_Free_Gold_Medal()
    {
        death.color = Color.white;
        int cost = 500;
        if (coin >= cost)
        {
            coin -= cost;
            Death_Free_Gold_Medal();
            Debug.Log("購買成功！");
        }
        else
        {
            Debug.Log("金幣不足！");
        }
    }

    public void ExitShop() 
    {
        ShopPanel.SetActive(false);
    }

}
