using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SimonButton : MonoBehaviour
{
    public Color buttonColor; // The color the button should revert to
    private Image buttonImage;
    private Vector3 originalScale; // Store the original scale for resetting

private void Awake()
{
    buttonImage = GetComponent<Image>();
    originalScale = transform.localScale;

    // Set a default color if not set properly in the inspector
    if (buttonColor == null || buttonColor.a == 0) 
    {
        buttonColor = new Color(0.8f, 0.8f, 0.8f, 1f); // Set a default grey color with full alpha
    }

    buttonImage.color = buttonColor;
    Debug.Log("Button Color (final): " + buttonImage.color);
}
    // Flash the button
    public void Flash(float duration)
    {
        StartCoroutine(FlashRoutine(duration));
    }

    // Change button color temporarily and scale up for shine effect
private IEnumerator FlashRoutine(float duration)
{
    Color originalColor = buttonImage.color;
    Debug.Log($"Original color: {originalColor}");
    
    buttonImage.color = Color.white; // Flash white
    Debug.Log("Flashing white");

    transform.localScale = originalScale * 1.1f; // Scale up

    yield return new WaitForSeconds(duration); 

    buttonImage.color = originalColor; // Restore original color
    Debug.Log($"Restored color: {originalColor}");
    
    transform.localScale = originalScale; // Reset scale
}

    private IEnumerator FlashButtons()
    {
        while (true) // Loop indefinitely
        {
            {
                Flash( 5); // Flash each button
                yield return new WaitForSeconds(5); // Wait before flashing the next button
            }

            yield return new WaitForSeconds(5); // Wait before starting the sequence again
        }
    }
    // Set the button color (used to turn all buttons red on failure)
    public void SetButtonColor(Color newColor)
    {
        buttonImage.color = newColor; // Change the Image color directly
    }
}