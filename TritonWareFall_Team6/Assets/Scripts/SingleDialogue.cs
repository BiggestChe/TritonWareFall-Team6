using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SingleDialogue : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    public string line;
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
            if (textbox.text == line)
            {
                EndTextBox();
            }
            else
            //shows whole text
            {
                StopAllCoroutines();
                textbox.text = line;
            }
        }
    }

    // This method is triggered externally to start the dialogue using onClick()
    public void TriggerDialogue(string dialogueLine) 
    {
        line = dialogueLine;
        isDialogueActive = true;
        textbox.text = string.Empty;
        gameObject.SetActive(true);  // Activate the dialogue UI
        StartCoroutine(TypeLine());
    }

    //prints out strings according to TextSpeed
    IEnumerator TypeLine()
    {
        foreach (char c in line.ToCharArray())
        {
            textbox.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

//goes to nextlines 
    void EndTextBox() {
        gameObject.SetActive(false);  // Hide dialogue when finished
        isDialogueActive = false;     // Dialogue is no longer active
    }
}