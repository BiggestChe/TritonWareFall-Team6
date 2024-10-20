using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Symbol : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    public Sprite[] symbolImg;
    public Puzzle2 puzzle;
    public int index;


    // Start is called before the first frame update
    void Start()
    { 
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void run(bool bval) {
        spriteRenderer.enabled = bval;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
