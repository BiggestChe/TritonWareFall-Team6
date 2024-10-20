using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExitScript : MonoBehaviour, IClickable
{
    public GameObject panel; // Reference to the panel to be deactivated

    public void Click()
    {
        ExitPanel(); // Call the method to exit the panel
    }

    void ExitPanel()
    {
        if (panel != null)
        {
            panel.SetActive(false); // Deactivate the panel
        }
        else
        {
            Debug.LogWarning("Panel reference is not assigned!");
        }
    }

    void OnMouseDown()
    {
        Click(); // Call Click method when the object is clicked
    }
}
