using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI")]
    public Text TextLabel;
    public Image CharacterImage;


    [Header("文本")]
    public TextAsset textFile;
    public int index;

    [Header("Image")]
    public Sprite Aeriya, Leader,Business,Bipe,Father,Mother,Ghost;

    private bool textfinish = true;

    List<string> textList = new List<string>();

    // Start is called before the first frame update
    void Awake()
    {
        textList.Clear();

    }
    private void OnEnable()
    {
        index = 0;
        textfinish = true;
        StartCoroutine(setTextUI());
    }
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.O) && textfinish)
        {
            if (index < textList.Count)
            {
                StartCoroutine(setTextUI());
            }
            else
            {
                gameObject.SetActive(false);
                index = 0;
            }
        }
    }

    public void GetTextFormFile(string label)
    {
        textList.Clear();
        string[] lines = textFile.text.Split('\n');
        bool readLine = false;

        foreach (string line in lines)
        {
            if (line.StartsWith("[") && line.Contains(label))
            {
                readLine = true;
                continue;
            }
            else if (line.StartsWith("[") && readLine)
            {
                break; 
            }

            if (readLine && !string.IsNullOrWhiteSpace(line))
             {
                textList.Add(line.Trim());
             }
            }
        index = 0; 
        textfinish = true;
    }

    IEnumerator setTextUI() 
    {
        
        textfinish = false;
        TextLabel.text = "";

        if (index >= textList.Count)
        {
            if (FindObjectOfType<DialogueTrigger>() != null)
            {
                FindObjectOfType<DialogueTrigger>().EndDialogue(); // 调用结束对话方法
            }
            gameObject.SetActive (false);
            yield break;
        }
        string currentLine = textList[index].Trim();
        

        char speaker = currentLine[0]; 
        string dialogue = currentLine.Substring(1).Trim(); 


        switch (speaker) 
        {
            case 'A':
                CharacterImage.sprite = Aeriya; break;
            case 'B':
                CharacterImage.sprite = Leader; break;
            case 'C':
                CharacterImage.sprite = Business; break;
            case 'D':
                CharacterImage.sprite = Bipe; break;
            case 'E':
                CharacterImage.sprite = Father; break;
            case 'F':
                CharacterImage.sprite = Mother; break;
            case 'G':
                CharacterImage.sprite = Ghost; break;
        }

        for (int i = 0; i < dialogue.Length; i++) 
        {
            TextLabel.text += dialogue[i];

            yield return new WaitForSeconds(0.05f);
        }
        textfinish = true;
        index++;
    }

    public void DisplayNextSentence()
    {
        if (textfinish && index < textList.Count)
        {
            StartCoroutine(setTextUI());
        }
        else if (index >= textList.Count)
        {
            FindObjectOfType<DialogueTrigger>().talkPanel.SetActive(false);
            gameObject.SetActive(false);
            index = 0; 
        }
    }
    //當需要條件去做觸發時 寫在其他腳本的東西 ex:boss死亡後的對話
    //public DialogueTrigger dialogueTrigger;
    // void TriggerDialogue()
    //{
    //    if (dialogueTrigger != null)
    //    {
    //        dialogueTrigger.dialogueLabel = "標籤"; 
    //       dialogueTrigger.enabled = true; 
    //   }
    //}
}
