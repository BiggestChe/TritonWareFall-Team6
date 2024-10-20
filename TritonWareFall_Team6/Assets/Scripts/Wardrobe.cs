using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wardrobe : MonoBehaviour, IClickable
{
    public GameObject WardrobeZoom;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        
    private void OpenWardrobe()
    {
        WardrobeZoom.SetActive(true); // Show the panel when clicked
    }

    public void Click()
    {
        OpenWardrobe();
        }
}

