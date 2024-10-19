using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Puzzle3 : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    public Sprite dollImg;
    public CloseButton closeButton;
    public Organ[] organList;
    public AnatomyDoll anatomyDoll;

    private int[] trueIndexList = {0, 2, 4, 6}; // 1, 3, 5, 7
    private HashSet<int> falseIndexSet = new HashSet<int> {1,3,5,7,8};

    private int puzzleOrganIndex = 0;
    private bool winCondition = true;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        for(int i = 0; i < organList.Length; i++) {
            organList[i].OrganEventOccurred += OnOrganEventOccurred;  // Subscribe to the event
            organList[i].index = i;
        }
    }

    public void run(bool bval) {
        spriteRenderer.enabled = bval;
        closeButton.run(bval);

        for(int i = 0; i < organList.Length; i++) {
            organList[i].run(bval);
        }
    }

    private void OnOrganEventOccurred(object sender, EventArgs e) {
        Organ clickedOrgan = sender as Organ;
        gameCheck(clickedOrgan.index);
        // Debug.Log("organ cllicked is "+ clickedOrgan.index.ToString());
    }

    private void gameCheck(int organIndex) {
        if(organIndex != trueIndexList[puzzleOrganIndex] || falseIndexSet.Contains(organIndex)) {
            winCondition = false;
        }

        puzzleOrganIndex += 1;
        organList[organIndex].run(false);
        if(puzzleOrganIndex == trueIndexList.Length) {
            if(winCondition) {
                // win condition 
                for(int i = 0; i < organList.Length; i++) {
                    organList[i].run(false);
                }
                this.run(false);
                closeButton.run(false);
                anatomyDoll.run(false);
            }
            else {
                // reset condition
                puzzleOrganIndex = 0;
                for(int i = 0; i < organList.Length; i++) {
                    organList[i].run(true);
                }
                winCondition = true;
            }
        }
    }

}
