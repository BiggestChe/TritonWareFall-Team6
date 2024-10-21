using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Organ : MonoBehaviour, IClickable {
    private SpriteRenderer spriteRenderer;
    private new Collider2D collider2D;
    public Sprite organImg;
    public Puzzle3 puzzle;
    public int index;

    public delegate void OrganEventHandler(object sender, EventArgs e);
    public event OrganEventHandler OrganEventOccurred;

    public void Click() {
        // Debug.Log($"Captured click at: {index}");
        TriggerEvent();
    }

    // Start is called before the first frame update
    void Start()
    { 
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        spriteRenderer.enabled = false;
        collider2D.enabled = false;         
    }

    public void run(bool bval) {
        spriteRenderer.enabled = bval;
        collider2D.enabled = bval;
    }
    public void TriggerEvent()
    {
        // Debug.Log($"Captured event at: {index}");
        OrganEventOccurred?.Invoke(this, EventArgs.Empty);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}