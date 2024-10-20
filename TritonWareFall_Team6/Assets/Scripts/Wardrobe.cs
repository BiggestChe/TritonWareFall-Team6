using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour,IClickable
{
    public SingleDialogue dialogue;
    public string[] dialogueLines;
    public Puzzle2 puzzle;
    // public bool hasScalpel = false;
    private new Collider2D collider2D;
    public void Click() {
        puzzle.run(true);
        this.run(false);
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
