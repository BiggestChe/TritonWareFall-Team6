using UnityEngine;

public class IPad : MonoBehaviour, IClickable
{
    public GameObject panel; // Reference to the panel you want to open

    // This is the method from IClickable interface that gets called when the object is clicked
    public void Click()
    {
        OpenPanel();
        Debug.Log("clicking this") ; 
         }

    private void OpenPanel()
    {
        panel.SetActive(true); // Show the panel when clicked
    }
}