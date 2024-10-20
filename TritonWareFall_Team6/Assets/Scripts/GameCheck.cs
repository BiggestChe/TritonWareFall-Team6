using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameCheck : MonoBehaviour
{

    public KeyCycler key1;
    public KeyCycler key2;
    public KeyCycler key3;

    int correctKey1Index = 1;

    int correctKey2Index = 0;

    int correctKey3Index = 2; 

    public Dialogue_Script dialogue;
    public string[] dialogueLines;

    public Scalpel scapel;

    public GameObject Wardrobe;
    
    
    // Start is called before the first frame update
public void CheckCombination()
{
    int key1Index = key1.GetCurrentKeyIndex();
    int key2Index = key2.GetCurrentKeyIndex();
    int key3Index = key3.GetCurrentKeyIndex();

    if (key1Index == correctKey1Index && key2Index == correctKey2Index && key3Index == correctKey3Index)
    {

        dialogue.TriggerDialogue(dialogueLines);
        scapel.SetScalpelTrue();
        Destroy(Wardrobe);

        }       
    else
    {
        Debug.Log("Incorrect combination. Try again!");
    }
}

    void Update(){
        if(Input.GetMouseButtonDown(0)){
                    CheckCombination();
        }
    }
}