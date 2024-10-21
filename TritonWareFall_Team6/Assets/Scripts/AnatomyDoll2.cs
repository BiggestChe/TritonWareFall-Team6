using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnatomyDoll : MonoBehaviour, IClickable
{
    public Dialogue_Script dialogue;
    public string[] dialogueLines;
    public Puzzle3 puzzle;
    public Scalpel scalpel;

    private new Collider2D collider2D;
    private bool playerHasScalpel = false; // New boolean to track if player has the scalpel

    public void Click()
    {
        // Check if the player has acquired the scalpel
        if (playerHasScalpel)
        {
            // If the player has the scalpel, show the second dialogue line and trigger the puzzle
            dialogue.TriggerDialogue(dialogueLines[1]);
            puzzle.run(true);
            this.run(false);  // Disable interaction with the doll after the puzzle starts
        }
        else
        {
            // If the player doesn't have the scalpel, show the first dialogue line
            dialogue.TriggerDialogue(dialogueLines[0]);
        }
    }

    public void run(bool bval)
    {
        collider2D.enabled = bval;
    }

    // This method will be called to set the playerHasScalpel boolean
    public void SetPlayerHasScalpel(bool hasScalpel)
    {
        playerHasScalpel = hasScalpel;
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
        // No need for constant checks, the doll's behavior is controlled by clicks
    }
}
