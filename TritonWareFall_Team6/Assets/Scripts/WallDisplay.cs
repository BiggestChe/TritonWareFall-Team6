using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//display includes movement, if we dont want it, go backwards lol!
public class WallDisplay : MonoBehaviour
{

    
    public Sprite[] backgroundSprites;
    public Wall[] wallList = new Wall[4];
    private SpriteRenderer spriteRenderer;
    private int currentWallIndex = 0;

    public float fadeDuration = 0.2f; // Duration for fade in/out transitions

    // Custom getter and setter for currentSpriteIndex
    public int CurrentWall
    {
        get 
        { 
            return currentWallIndex; 
        }
        set
        {
            if (value < 0)
                value = wallList.Length - 1; // Wraps around from 0 to last sprite
            value = value % wallList.Length;
            currentWallIndex = value;
        }
    }

    void Start()
    {
        // Cache the SpriteRenderer component for easy access
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = backgroundSprites[currentWallIndex]; // Set the initial sprite

        for(int i = 0; i < 4; i++) { // add 4 walls
            Sprite sprite = backgroundSprites[i];
            Wall wall = new Wall(sprite, i);
            wallList[i] = wall;
        }
    }

    void Update()
    {
        // Move left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(FadeTransition(currentWallIndex - 1));
        }

        // Move right
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(FadeTransition(currentWallIndex + 1));
        }
    }

//FADING IS OPTIONAL, MAY FEEL SLOW LOL
    // Coroutine to handle the fade transition
    IEnumerator FadeTransition(int newWallIndex)
    {
        // Fade out
        yield return StartCoroutine(FadeOut());

        // Change the sprite after fade out
        CurrentWall = newWallIndex;
        spriteRenderer.sprite = wallList[CurrentWall].getSprite();

        // Fade in
        yield return StartCoroutine(FadeIn());
    }

    // Coroutine to fade out the sprite
    IEnumerator FadeOut()
    {
        for (float t = 0f; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            spriteRenderer.color = new Color(1f, 1f, 1f, alpha); // Modify the alpha channel
            yield return null;
        }
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f); // Ensure it's fully transparent at the end
    }

    // Coroutine to fade in the sprite
    IEnumerator FadeIn()
    {
        for (float t = 0f; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            spriteRenderer.color = new Color(1f, 1f, 1f, alpha); // Modify the alpha channel
            yield return null;
        }
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f); // Ensure it's fully opaque at the end
    }
}

