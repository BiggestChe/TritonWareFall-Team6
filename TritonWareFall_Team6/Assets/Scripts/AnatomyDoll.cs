using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnatomyDoll : MonoBehaviour,IClickable
{
    public SingleDialogue dialogue;
    public string[] dialogueLines;
    public Puzzle3 puzzle;
    public bool hasScalpel = false;
    private new Collider2D collider2D;
    public void Click() {
        if(hasScalpel) {
            dialogue.TriggerDialogue(dialogueLines[1]);
            puzzle.run(true);
            this.run(false);
        }
        else {
            dialogue.TriggerDialogue(dialogueLines[0]);
        }
    }
    public void run(bool bval) {
        collider2D.enabled = bval;
    }

    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        collider2D.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
