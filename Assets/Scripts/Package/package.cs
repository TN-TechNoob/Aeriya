using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class package : MonoBehaviour
{
    public GameObject packagePanel;
    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        packagePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            packagePanel.SetActive(true);
        }
    }
    public void Exitpackage() 
    {
        packagePanel.SetActive(false);

    }

}
