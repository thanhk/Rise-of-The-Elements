using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public ItemType itemType;
    public int amount;

    public enum ItemType{
        Sword,
        Staff,
        RedPot,
        BluePot,
    }

	public Sprite GetSprite(){
		switch(itemType){
			default:
			case ItemType.Sword:
				return ItemAssets.Instance.swordSprite;
			case ItemType.Staff:
				return ItemAssets.Instance.staffSprite;
			case ItemType.RedPot:
				return ItemAssets.Instance.redPotSprite;
			case ItemType.BluePot:
				return ItemAssets.Instance.bluePotSprite;
		}
	}

	public bool IsStackable(){
		switch(itemType){
			default:
			case ItemType.RedPot:
			case ItemType.BluePot:
				return true; //stackable items
			case ItemType.Sword:
			case ItemType.Staff:
				return false; //nonstackable items
		}
	} 

}
