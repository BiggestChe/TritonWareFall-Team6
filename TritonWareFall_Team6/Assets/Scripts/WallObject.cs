using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// TODO: Look up how to create an image object and show them and hide them when needed.
public class WallObject
{
    private Sprite sprite;
    private GameObject gameObject = new GameObject();
    private SpriteRenderer spriteRenderer;
    public WallObject() {}
    public WallObject(Sprite sprite) {
        // In the future, sprite should be loaded from the Wall_i folders instead of passed thru from WallDisplay.
        spriteRenderer= gameObject.AddComponent<SpriteRenderer>(); // Add a SpriteRenderer
        spriteRenderer.sprite = sprite; // Assign the sprite to the SpriteRenderer
    }
    public WallObject(string spritePath) {
        // In the future, sprite should be loaded from the Wall_i folders instead of passed thru from WallDisplay.
        spriteRenderer= gameObject.AddComponent<SpriteRenderer>(); // Add a SpriteRenderer
        spriteRenderer.sprite = loadSprite(spritePath); // Assign the sprite to the SpriteRenderer
        gameObject.transform.position = new Vector3(325, 147, 1);
        spriteRenderer.sortingOrder= 10; 
        Debug.Log(spriteRenderer.sprite.GetType());
    }

    // TODO: Complete the render pipeline. When there's an update in WallDisplay, that will riple down to Object in that Wall to showup.
    public void render() {
        // No logic for now, will add when there's objects sprite
    }

    // Helper to load Sprite from Resources
    public Sprite loadSprite(string path) {
        return Resources.Load<Sprite>(path);
    }

}