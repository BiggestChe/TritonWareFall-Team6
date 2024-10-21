using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Puzzle3 : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    public SpriteRenderer wallNote;
    public Sprite dollImg;
    public CloseButton closeButton;
    public Organ[] organList;
    public Organ key;
    public AnatomyDoll anatomyDoll;

    private int[] trueIndexList = {0, 2, 4, 6, 5, 1}; // 1, 3, 5, 7, 6, 2
    // private HashSet<int> falseIndexSet = new HashSet<int> {3,7};

    private int puzzleOrganIndex = 0;
    private bool winCondition = true;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        wallNote.enabled = false;
        spriteRenderer.enabled = false;

        for(int i = 0; i < organList.Length; i++) {
            organList[i].OrganEventOccurred += OnOrganEventOccurred;  // Subscribe to the event
            organList[i].index = i;
        }
        key.index = 8;
        key.OrganEventOccurred += OnOrganEventOccurred;
    }

    public void run(bool bval) {
        spriteRenderer.enabled = bval;
        wallNote.enabled = bval;
        closeButton.run(bval);
        key.run(bval);


        for(int i = 0; i < organList.Length; i++) {
            organList[i].run(bval);
            Debug.Log("running");
        }
    }

    private void OnOrganEventOccurred(object sender, EventArgs e) {
        Organ clickedOrgan = sender as Organ;
        gameCheck(clickedOrgan.index);
    }

    private void gameCheck(int organIndex) {
        if(organIndex == 8) { // clicked on key
            // win
            for(int i = 0; i < organList.Length; i++) {
                organList[i].run(false);
            }
            this.run(false);
            closeButton.run(false);
            anatomyDoll.run(false);
            key.run(false);
            return;
        }

        if (puzzleOrganIndex >= trueIndexList.Length) {
            Reset();
            return;
        }

        if(organIndex != trueIndexList[puzzleOrganIndex]) {
            winCondition = false;
        }

        puzzleOrganIndex += 1;
        organList[organIndex].run(false);
        if(puzzleOrganIndex == trueIndexList.Length) {
            if(winCondition) {
                // setup key 
                key.run(true);
            }
            else {
                // reset condition
                Reset();
            }
        }


    }

    public void Reset() {
        puzzleOrganIndex = 0;
        for(int i = 0; i < organList.Length; i++) {
            organList[i].run(true);
        }
        key.run(false);
        winCondition = true;
    }

}
