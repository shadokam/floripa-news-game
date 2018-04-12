using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public List<string> dialogueLines = new List<string>();
    public GameObject dialoguePanel;
    public string npcName;

    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;

    public static Dialogue instance2 { get; set; }

    void Awake()
    {
        dialoguePanel.SetActive(false);
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });

        if (instance2 != null)
        {
            Debug.LogWarning("Mais de uma instancia de diálogo");
            return;
        }

        instance2 = this;
    }


    public void AddNewDialogue(string [] lines, string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npcName = npcName;
        CreateDialogue();
    }
 

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        NewMethod();
        dialoguePanel.SetActive(true);
    }

    private void NewMethod()
    {
        nameText.text = npcName;
    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count-1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerMotor>().enabled = true;
        }
    }
}
