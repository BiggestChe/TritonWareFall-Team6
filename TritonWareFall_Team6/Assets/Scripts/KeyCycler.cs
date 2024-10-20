using UnityEngine;
using UnityEngine.UI;

public class KeyCycler : MonoBehaviour
{
    public Image keyImage; // Assign this to the button's Image component
    public Sprite[] keyImages; // Array of key images
    private int currentIndex = 0; // Current index of the displayed key image

    private void Start()
    {
        // Initialize the key image to the first sprite
        UpdateKeyImage();
    }

    // Method to cycle the key image
    public void CycleKeyImage()
    {
        currentIndex = (currentIndex + 1) % keyImages.Length;
        UpdateKeyImage();
    }

    private void UpdateKeyImage()
    {
        keyImage.sprite = keyImages[currentIndex]; // Update the button's image
    }


    // You can create a method to get the current key index if needed
    public int GetCurrentKeyIndex()
    {
        Debug.Log(currentIndex);
        return currentIndex; // Return the current key index
    }
}

