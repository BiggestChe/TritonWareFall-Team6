using UnityEngine;
using UnityEngine.UI; // For UI components

public class Scalpel : MonoBehaviour
{
    public bool scalpel = false;
    public Image scalpelIcon; // Reference to the UI Image for the scalpel icon
    public AnatomyDoll anatomyDoll; // Reference to the AnatomyDoll script

    public void SetScalpelTrue()
    {
        scalpel = true;
        Debug.Log("Scalpel acquired!");
        ShowScalpelIcon();
        anatomyDoll.SetPlayerHasScalpel(true); // Inform the AnatomyDoll that the player has the scalpel
    }

    public void ShowScalpelIcon()
    {
        if (HasScalpel())
        {
            scalpelIcon.enabled = true; // Enable the UI Image to make the icon visible
        }
    }

    public bool HasScalpel()
    {
        return scalpel;
    }
}
