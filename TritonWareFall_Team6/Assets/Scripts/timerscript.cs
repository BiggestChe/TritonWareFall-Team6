using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timerscript : MonoBehaviour

{
    public TextMeshProUGUI textbox; 
    float time = 600f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        time -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(time / 60);

        int seconds = Mathf.FloorToInt(time % 60);

        //string.format converts string and formats data into certain place
        // {0} is index of object
        textbox.color = Color.red;
        textbox.text = string.Format("{0:00} : {1:00}", minutes, seconds);

        
    }
}
