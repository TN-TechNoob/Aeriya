using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    public GameObject choosePanel;
    private bool nearby = false;

    // Start is called before the first frame update
    void Start()
    {
        choosePanel.SetActive(false);
    }
    public void openpanel() 
    {
        if (nearby)
        {
           

        choosePanel.SetActive(true);
        }
    
    }

    public void leftLevel() 
    {
        SceneManager.LoadScene(1);

    }

    public void rightLevel()
    {
       // SceneManager.LoadScene(2);

    }

    public void closepanel() 
    {
    
        choosePanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            nearby = true;
            Debug.Log("Player entered the trigger area."); // 測試用
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            nearby = false;
            closepanel();
            Debug.Log("Player left the trigger area."); // 測試用
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (nearby)
        {
            openpanel();
        }
    }
}
