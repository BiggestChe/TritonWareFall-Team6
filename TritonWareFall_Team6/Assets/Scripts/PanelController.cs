using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject simonSaysPanel; // Reference to the panel

    // Call this function when the player clicks the sprite or button to show the panel
    public void ShowPanel()
    {
        simonSaysPanel.SetActive(true); // Set the panel to be active (visible)
    }

    // Optional: Call this function to hide the panel when needed
    public void HidePanel()
    {
        simonSaysPanel.SetActive(false); // Set the panel to be inactive (hidden)
    }
}
