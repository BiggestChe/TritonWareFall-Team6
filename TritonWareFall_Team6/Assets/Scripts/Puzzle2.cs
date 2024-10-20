using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Puzzle2 : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    public Sprite dollImg;
    public Puzzle2CloseButton closeButton;
    public Wardrobe wardrobe;

    public Symbol[] symbolList;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        for(int i = 0; i < symbolList.Length; i++) {
            symbolList[i].index = i;
        }
    }

    public void run(bool bval) {
        spriteRenderer.enabled = bval;
        closeButton.run(bval);

        for(int i = 0; i < symbolList.Length; i++) {
            symbolList[i].run(bval);
        }
    }

    private void OnSymbolEventOccurred(object sender, EventArgs e) {

    }

    private void gameCheck(int organIndex) {

    }

    public void reset() {
        for(int i = 0; i < symbolList.Length; i++) {
            symbolList[i].run(true);
        }
    }

}
