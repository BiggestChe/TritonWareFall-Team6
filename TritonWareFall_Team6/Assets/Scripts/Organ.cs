using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organ : MonoBehaviour, IClickable {
    private SpriteRenderer spriteRenderer;
    public Sprite organImg;

    public void Click() {
        
    }

    // Start is called before the first frame update
    void Start()
    { 
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
