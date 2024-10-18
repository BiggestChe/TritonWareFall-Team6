using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour, IClickable
{
    public Dialogue_Script dialogue;
    public string[] dialogueLines;
    public void Click()
    {

        dialogue.TriggerDialogue(dialogueLines);

            }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
