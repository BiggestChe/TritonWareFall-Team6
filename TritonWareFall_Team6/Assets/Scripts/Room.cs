using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall
{
    public Object[] objectList;
    private Sprite backgroundSprite;
    private int roomIndex;

    public Wall(Sprite backgroundSprite, int roomIndex) {
        // In the future, sprite should be loaded from the Walli folders instead of passed thru from WallDisplay.
        this.backgroundSprite = backgroundSprite;
        this.roomIndex = roomIndex;
    }

    public Sprite getSprite() {
        return this.backgroundSprite;
    }

    public void render() {
        for(int i = 0; i < objectList.Length; i++) {
            objectList[i].render();
        }
    }


}