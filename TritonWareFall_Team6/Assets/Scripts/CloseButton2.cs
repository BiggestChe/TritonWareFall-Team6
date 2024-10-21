using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour, IClickable
{
    public AnatomyDoll anatomyDoll;
    public Puzzle3 puzzle;
    private new Collider2D collider2D;
    private SpriteRenderer spriteRenderer;
    public Sprite buttonImg;
    public void Click()
    {
        puzzle.Reset();
        puzzle.run(false);
        anatomyDoll.run(true);
    }
    public void run(bool bval) {
        spriteRenderer.enabled = bval; 
        collider2D.enabled = bval;
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
