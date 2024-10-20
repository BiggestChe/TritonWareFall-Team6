using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HiddenFileManager : MonoBehaviour, IClickable
{

    public Image[] images; // Array of images to cycle through
    public GameObject HiddenFile;

    public GameObject Panel;
    public float flashDuration = 0.5f; // Time for each image to stay on the screen
    public float delayBetweenFlashes = 0.2f; // Delay between flashing each image

    public bool isFlashing;

    void Start(){
        HiddenFile.SetActive(false);
    }

        public void Click()
    {
        Debug.Log("Supposed to Flash");
        StartCoroutine(FlashSequence());

    }
    IEnumerator FlashSequence()
    {
        isFlashing = true;

        // Loop through the images and show them one by one
        for (int i = 0; i < images.Length; i++)
        {
            images[i].enabled = true; // Show the image
            yield return new WaitForSeconds(flashDuration); // Wait for the flash duration
            images[i].enabled = false; // Hide the image

            if (i < images.Length - 1) // Add delay between images
            {
                yield return new WaitForSeconds(delayBetweenFlashes);
            }
        }

        isFlashing = false;
    }


}