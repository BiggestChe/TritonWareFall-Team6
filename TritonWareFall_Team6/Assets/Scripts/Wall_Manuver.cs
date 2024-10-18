using UnityEngine;

public class WallSwitcher : MonoBehaviour
{
    public Camera mainCamera;  // Assign your main camera in the Inspector

    public GameObject[] wallObjects; 
    private int currentWallIndex = 0;
    private string[] wallLayers = { "Wall1", "Wall2", "Wall3", "Wall4" };

    void Start()
    {
        ShowCurrentWall();  // Start by showing the first wall (Wall1)
    }

    void Update()
    {
        // Switch to the next wall when the right arrow key is pressed
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentWallIndex = (currentWallIndex + 1) % wallLayers.Length;
            ShowCurrentWall();
        }

        // Switch to the previous wall when the left arrow key is pressed
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentWallIndex = (currentWallIndex - 1 + wallLayers.Length) % wallLayers.Length;
            ShowCurrentWall();
        }
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

        /*
        if(currentWallIndex != 0) {
        for (int i = 0; i < wallObjects.Length; i++)
        {
            wallObjects[i].SetActive(false);  // Only enable the active wall's objects
        }
        }
        else {
        for (int i = 0; i < wallObjects.Length; i++)
        {
            wallObjects[i].SetActive(true);  // Only enable the active wall's objects
        }
        }
        */

                for (int i = 0; i < wallObjects.Length; i++)
        {
            wallObjects[i].SetActive(i == currentWallIndex);  // Only enable the active wall's objects
        }

    }
}