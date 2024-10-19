using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnatomyDoll : MonoBehaviour, IClickable
{
    public Dialogue_Script dialogue;
    // private Puzzle1 puzzle;
    public string[] dialogueLines;
    public void Click()
    {
        dialogue.TriggerDialogue(dialogueLines);
        // puzzle.run();
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
