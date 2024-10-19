using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SimonButton : MonoBehaviour
{
    public Color buttonColor;
    private Image buttonImage;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.color = buttonColor; // Set the button's color
    }

    // Flash the button
    public void Flash(float duration)
    {
        StartCoroutine(FlashRoutine(duration));
    }

    // Change button color temporarily
    private IEnumerator FlashRoutine(float duration)
    {
        Color originalColor = buttonImage.color;
        buttonImage.color = Color.white; // Flash white
        yield return new WaitForSeconds(duration);
        buttonImage.color = originalColor;
    }

    // Set the button color (used to turn all buttons red on failure)
    public void SetButtonColor(Color newColor)
    {
        buttonImage.color = newColor;
    }
}