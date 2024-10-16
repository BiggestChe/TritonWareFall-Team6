using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object
{
    private Sprite sprite;
    private GameObject gameObject;

    public Object(Sprite sprite) {
        // In the future, sprite should be loaded from the Wall_i folders instead of passed thru from WallDisplay.
        this.sprite = sprite;
        gameObject = new GameObject(); // Create a new GameObject
        SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>(); // Add a SpriteRenderer
        spriteRenderer.sprite = this.sprite; // Assign the sprite to the SpriteRenderer
    }



}