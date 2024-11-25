using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
   public GameObject ShopPanel;
    private bool nearby=false;

    // Start is called before the first frame update
    void Start()
    {
        if (ShopPanel != null)
        {
            ShopPanel.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nearby = true;
        }
    }
    private void OnTriggerExit(Collider other)
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
}
