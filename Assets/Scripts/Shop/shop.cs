using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
   public GameObject ShopPanel;
    private bool nearby=false;

    public Text count;
    private int counter;

    public Image stamina;
    public Image source;
    public Image death;

    [SerializeField] public PlayerHealth playerHealth;


    //public GameObject coinprefab;

    public int coin = 1000; //FOR TEST

    // Start is called before the first frame update
    void Start()
    {
        if (ShopPanel != null)
        {
            ShopPanel.SetActive(false);
        }
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
    }
    public void Restoration_Potion()
    {
        if (playerHealth != null)
        {
            playerHealth.AddHealth(6);
        }
    }
    public void Buy_Restoration_Potion()
    {
        counter++;
        count.text = counter.ToString();
        int cost = 50;
        if (coin >= cost)
        {
            coin -= cost;
            Restoration_Potion(); 
            Debug.Log("購買成功！");
        }
        else
        {
            Debug.Log("金幣不足！");
        }
    }
    private IEnumerator Stamina_Charm()
    {
        while (true)                    
        {
            yield return new WaitForSeconds(5);
            playerHealth.AddStrength(2); 
        }
    }
    public void Buy_stamina_charm()
    {
        stamina.color = Color.white;
        int cost = 300;
        if (coin >= cost)
        {
            coin -= cost;
            Stamina_Charm();
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
