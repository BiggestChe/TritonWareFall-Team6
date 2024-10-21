using UnityEngine;

public class StartScreen : MonoBehaviour, IClickable
{
    public GameObject startScreenPanel; // Assign the Start Screen Panel in the Inspector
    public WallSwitcher walls;  // Reference to the WallSwitcher script

    public Timerscript timer;

    public void Click()
    {
        Debug.Log("I AM CLICKING ON THIS");
        StartGame();
        }

    public void StartGame()
    {
        startScreenPanel.SetActive(false);  // Hide the start screen
        walls.MovementActive(); // Enable wall switching
    }
}