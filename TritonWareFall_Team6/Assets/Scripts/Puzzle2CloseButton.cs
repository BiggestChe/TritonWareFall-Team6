using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2CloseButton : MonoBehaviour, IClickable
{
    public Wardrobe wardrobe;
    public Puzzle2 puzzle;
    private new Collider2D collider2D;
    private SpriteRenderer spriteRenderer;
    public Sprite buttonImg;
    public void Click()
    {
        puzzle.reset();
        puzzle.run(false);
        wardrobe.run(true);
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
