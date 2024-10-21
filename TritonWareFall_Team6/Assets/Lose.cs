using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public WallSwitcher walls; 
    public SpriteRenderer losescreen;
    // Start is called before the first frame update
    void Start()
    {
        walls.MovementOff();
        losescreen = GetComponent<SpriteRenderer>();
        losescreen.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
