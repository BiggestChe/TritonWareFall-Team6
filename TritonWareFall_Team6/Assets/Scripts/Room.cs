using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall
{
    public Object[] objectList;
    private SpriteRenderer spriteRenderer;
    private Sprite backgroundSprite;
    private int roomIndex;

    public Wall(Sprite backgroundSprite, int roomIndex) {
        this.backgroundSprite = backgroundSprite;
        this.roomIndex = roomIndex;
    }   




}