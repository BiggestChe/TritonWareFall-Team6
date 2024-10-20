using UnityEngine;
using UnityEngine.UI; // For UI components

public class Scalpel : MonoBehaviour
{
    public bool scalpel = false;
    public Image scalpelIcon; // Reference to the UI Image for the scalpel icon

    public void SetScalpelTrue()
    {
        scalpel = true;
        Debug.Log("Scalpel acquired!");
        ShowScalpelIcon();
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
