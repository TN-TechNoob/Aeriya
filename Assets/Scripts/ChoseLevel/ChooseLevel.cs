using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseLevel : MonoBehaviour
{
    public LevelLoader levelLoader;
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
        levelLoader.LoadCustomLevel(2);
    }

    public void rightLevel()
    {
       levelLoader.LoadCustomLevel(3);
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
            Debug.Log("Player entered the trigger area."); // ���ե�
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            nearby = false;
            closepanel();
            Debug.Log("Player left the trigger area."); // ���ե�
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (nearby )
        {
            openpanel();
        }
    }
}
