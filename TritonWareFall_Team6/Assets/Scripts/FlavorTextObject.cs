using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlavorTextObject : MonoBehaviour,IClickable
{
    public SingleDialogue dialogue;
    public string dialogueLine;
    private new Collider2D collider2D;
    public void Click() {
        dialogue.TriggerDialogue(dialogueLine);
    }

    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        collider2D.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
