using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour, IClickable
{
    public AnatomyDoll anatomyDoll;
    public Puzzle3 puzzle;
    public new Collider2D collider2D;
    private SpriteRenderer spriteRenderer;
    public Sprite buttonImg;
    public void Click()
    {
        puzzle.run(false);
        anatomyDoll.run(true);
    }
    public void run(bool bval) {
        spriteRenderer.enabled = bval; 
        collider2D.enabled = bval;
        anatomyDoll.run(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = buttonImg; // Set the initial sprite 
        // spriteRenderer.sortingOrder = 0; 
        // spriteRenderer.sortingLayerName = "PuzzleLayer";
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
