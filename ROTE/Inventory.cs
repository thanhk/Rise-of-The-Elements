using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;
    private Action<Item> useItemAction;
    private int capacity = 4;

    public Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();

        //AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Staff, amount = 1 });
        
        //UnityEngine.Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        if(item.IsStackable()){
            bool itemAlreadyInInventory = false;
            foreach(Item inventoryItem in itemList){
                if(inventoryItem.itemType == item.itemType){
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if(!itemAlreadyInInventory){
                itemList.Add(item);
            }
        }
        else{
            itemList.Add(item);
        }
        
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item){
        if(item.IsStackable()){
                    Item itemInInventory = null;
                    foreach(Item inventoryItem in itemList){
                        if(inventoryItem.itemType == item.itemType){
                            inventoryItem.amount -= 1;
                            itemInInventory = inventoryItem;
                        }
                    }
                    if(itemInInventory != null && itemInInventory.amount <= 0){
                        itemList.Remove(itemInInventory);
                    }
                }
                else{
                    itemList.Remove(item);
                }
                
                OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool isFull(Item item){
        //maybe more logic here if stackable items have a max stack size
        if(item.IsStackable()){
            foreach(Item inventoryItem in itemList){
                if(inventoryItem.itemType == item.itemType){
                    return false;
                }
            }
        }
        if(itemList.Count >= capacity){
            return true;
        }
        return false;
    }

    public int GetCapacity(){
        return capacity;
    }

    public int GetSize(){
        return itemList.Count;
    }
    public void UseItem(Item item){
        useItemAction(item);
    }

    public List<Item> GetItemList(){
        return itemList;
    }
}
