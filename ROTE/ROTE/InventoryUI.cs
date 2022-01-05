using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private EarthPlayerMovement player;

    private void Awake(){
    	itemSlotContainer = transform.Find("itemSlotContainer");
    	itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");

    }

    public void SetPlayer(EarthPlayerMovement player){
    	this.player = player;
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e){
    	RefreshInventoryItems();
    }

    private void RefreshInventoryItems(){
    	//destroy items (UI element) previously in inventory
    	foreach(Transform child in itemSlotContainer){
    		if(child == itemSlotTemplate) continue;
    		Destroy(child.gameObject);
    	}

    	//numbers for spacing
    	int x = 0;
    	int y = 0;
    	float itemSlotCellSize = 23f;

    	//display each item in inventory
    	foreach(Item item in inventory.GetItemList()){

    		//creating item "slots" in UI and printing image from assets
    		RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
    		itemSlotRectTransform.gameObject.SetActive(true);
    		
    		itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => { //use item
    			inventory.UseItem(item);
    		};
			itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () => { //drop item
				Item itemHolder = new Item{itemType = item.itemType, amount = 1};
				inventory.RemoveItem(item);
				ItemWorld.DropItem(player.transform.position, itemHolder);
    		};

    		itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);
    		Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
    		image.sprite = item.GetSprite();
    		
    		Text text = itemSlotRectTransform.Find("amount").GetComponent<Text>();
    		if(item.amount > 1){ //display item counter more than 1
    			text.text = item.amount.ToString();
    		}
    		else{
    			text.text = "";
    		}

    		//next column, row
    		x++;
    		if(x>3){
    			x = 0;
    			y++;
    		}
    	}
    }
}
