using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall
{
    public List<WallObject> objectList = new List<WallObject>();
    private Sprite backgroundSprite;
    private int roomIndex;

    public Wall(Sprite backgroundSprite, int roomIndex) {
        // In the future, sprite should be loaded from the Walli folders instead of passed thru from WallDisplay.
        this.backgroundSprite = backgroundSprite;
        this.roomIndex = roomIndex;


        // For testing
        if(roomIndex == 1) {
            WallObject testobj = new WallObject("Art/Wall_1/Objects/test");
            objectList.Add(testobj);
        }
    }

    public Sprite getSprite() {
        return this.backgroundSprite;
    }

    public void render() {
        for(int i = 0; i < objectList.Count; i++) {
            objectList[i].render();
        }
    }


}