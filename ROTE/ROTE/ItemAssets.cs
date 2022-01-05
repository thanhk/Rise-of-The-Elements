using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance{get; private set; }

    private void Awake(){
    	Instance = this;
    }

    public Transform ItemWorld;

    public Sprite swordSprite;
    public Sprite staffSprite;
    public Sprite redPotSprite;
    public Sprite bluePotSprite;
}
