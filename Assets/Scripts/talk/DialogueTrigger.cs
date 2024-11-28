using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string dialogueLabel; 
    public DialogueSystem DialogueSystem;
    public GameObject talkPanel; 
    private bool nearby = false;
    private bool dialogueActive = false;

    private void Start()
    {
        talkPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        {
            nearby = true;
            
           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            nearby = false;
            talkPanel.SetActive(false); 
        

            if (dialogueActive && DialogueSystem != null)
            {
                DialogueSystem.gameObject.SetActive(false);
                dialogueActive = false;
            }
        }
    }

    private void Update()
    {
        if (nearby && Input.GetKeyDown(KeyCode.O))
        {
            if (!dialogueActive)
            {
                talkPanel.SetActive(true); 
                DialogueSystem.GetTextFormFile(dialogueLabel);
                DialogueSystem.gameObject.SetActive(true);
                dialogueActive = true;
            }
            else
            {
                
                DialogueSystem.DisplayNextSentence();
            }
        }
    }
    public void EndDialogue()
    {
        dialogueActive = false;
        if (talkPanel != null)
        {
            talkPanel.SetActive(false);
        }
        if (DialogueSystem != null)
        {
            DialogueSystem.gameObject.SetActive(false); // 隱藏對話系統
        }
    }

}
