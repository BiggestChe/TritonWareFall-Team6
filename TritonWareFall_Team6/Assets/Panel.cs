using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{

    public GameObject panel;
    public GameManager simonsays;

    internal void SetActive(bool v)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {        
        panel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()

    {
        if(panel.activeInHierarchy){
        simonsays.StartNewRound(); // Start Simon Says
        }
    }
}
