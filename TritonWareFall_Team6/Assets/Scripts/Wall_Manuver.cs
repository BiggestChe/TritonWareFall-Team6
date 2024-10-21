using UnityEngine;
using UnityEngine.UI;  // Required for UI components
using System.Collections;
using System.Runtime.Serialization.Formatters;

public class WallSwitcher : MonoBehaviour
{
    public Camera mainCamera;  // Assign your main camera in the Inspector
    public GameObject[] wallObjects;  // Assign parent GameObjects for each wall in the Inspector
    public Image fadeImage;  // Assign the UI Image that will handle fading in the Inspector
    public float fadeDuration = 1f;  // Time it takes to fade in/out

    private int currentWallIndex = 0;
    private string[] wallLayers = { "Wall1", "Wall2", "Wall3", "Wall4" };

    public bool CanMove;

    void Start()
    {
        ShowCurrentWall();  // Start by showing the first wall (Wall1)
        fadeImage.color = new Color(0, 0, 0, 0);  // Ensure the fade image is transparent at the start
    }

    void Update()
    {
        if(CanMove){

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentWallIndex = (currentWallIndex + 1) % wallLayers.Length;
            StartCoroutine(FadeAndSwitchWall());
        }

        // Switch to the previous wall when the left arrow key is pressed
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentWallIndex = (currentWallIndex - 1 + wallLayers.Length) % wallLayers.Length;
            StartCoroutine(FadeAndSwitchWall());
        }
        }
    }

    public void MovementActive(){
        CanMove = true;

    }

    // Coroutine to handle fade in/out effect and switch walls
    IEnumerator FadeAndSwitchWall()
    {
        // Fade out to black
        yield return StartCoroutine(Fade(1));

        // Switch wall visibility
        ShowCurrentWall();

        // Fade back in to the game (fade out the black screen)
        yield return StartCoroutine(Fade(0));
    }

    // This method shows the current wall based on the currentWallIndex
    void ShowCurrentWall()
    {
        // Get the current wall layer
        string currentWallLayer = wallLayers[currentWallIndex];

        // Convert the layer name to a layer mask and set the camera's culling mask
        int layerMask = 1 << LayerMask.NameToLayer(currentWallLayer);

        // Set the camera to only render the current wall
        mainCamera.cullingMask = layerMask;

        // Activate only the current wall objects
        for (int i = 0; i < wallObjects.Length; i++)
        {
            wallObjects[i].SetActive(i == currentWallIndex);
        }
    }

    // Coroutine to fade the screen to/from black
    IEnumerator Fade(float targetAlpha)
    {
        Color fadeColor = fadeImage.color;
        float startAlpha = fadeColor.a;
        float timeElapsed = 0;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, timeElapsed / fadeDuration);
            fadeColor.a = newAlpha;
            fadeImage.color = fadeColor;
            yield return null;  // Wait for the next frame
        }

        // Ensure final alpha is set after fading
        fadeColor.a = targetAlpha;
        fadeImage.color = fadeColor;
    }
}