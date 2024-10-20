using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sprite : MonoBehaviour
{
    public Image image; 
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
void Update()
{
    if (Input.GetKeyDown(KeyCode.Space)) // Press Space to flash the button
    {
        Debug.Log("pressing!");
        image.color = Color.black;
    }
}
}