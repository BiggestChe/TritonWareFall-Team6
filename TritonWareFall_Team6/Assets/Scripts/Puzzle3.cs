using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    public Sprite dollImg;
    public CloseButton closeButton;
    public Organ[] organList;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = dollImg; // Set the initial sprite 
        spriteRenderer.enabled = false;
    }

    public void run(bool bval) {
        spriteRenderer.enabled = bval;
        closeButton.run(bval);
    }
}
