using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnatomyDoll : MonoBehaviour,IClickable
{
    public Puzzle3 puzzle;
    public new Collider2D collider2D;
    public void Click() {
        puzzle.run(true);
    }
    public void run(bool bval) {
        collider2D.enabled = bval;
    }

    // Start is called before the first frame update
    void Start()
    {
        collider2D.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
