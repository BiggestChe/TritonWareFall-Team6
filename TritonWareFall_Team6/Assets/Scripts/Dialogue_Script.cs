using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue_Script : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    public string[] lines;
    public float textSpeed;

    private int index;
    private bool isDialogueActive = false; // Track if the dialogue is active

    // Start is called before the first frame update
    void Start()
    {
        textbox.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {

        if (isDialogueActive && Input.GetMouseButtonDown(0))
        {
            //recognizes if textbox is full
            if (textbox.text == lines[index])
            {
                NextLine();
            }
            else
            //shows whole text
            {
                StopAllCoroutines();
                textbox.text = lines[index];
            }
        }
    }

    // This method is triggered externally to start the dialogue using onClick()
    public void TriggerDialogue(string[] dialogueLines) 
    {
        lines = dialogueLines;
        isDialogueActive = true;
        index = 0;
        textbox.text = string.Empty;
        gameObject.SetActive(true);  // Activate the dialogue UI
        StartCoroutine(TypeLine());
    }

    //prints out strings according to TextSpeed
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textbox.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

//goes to nextlines 
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textbox.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);  // Hide dialogue when finished
            isDialogueActive = false;     // Dialogue is no longer active
        }
    }
}