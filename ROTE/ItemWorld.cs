using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{

	public static ItemWorld SpawnItemWorld(Vector3 position, Item item){
		Transform transform = Instantiate(ItemAssets.Instance.ItemWorld, position, Quaternion.identity);

		ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
		itemWorld.SetItem(item);

		return itemWorld;
	}

    public static ItemWorld DropItem(Vector3 position, Item item){
        Vector3 direction = new Vector3(0f,-.3f,0f); //pass in player direction later
        ItemWorld itemWorld = SpawnItemWorld(position + direction * 5f, item);
        itemWorld.GetComponent<Rigidbody2D>().AddForce(direction * 5f, ForceMode2D.Impulse);

        return itemWorld;
    }

    private Item item;

    private SpriteRenderer spriteRenderer;

    private void Awake(){
    	spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItem(Item item){
    	this.item = item;
    	spriteRenderer.sprite = item.GetSprite();
    }

    public Item GetItem(){
    	return item;
    }

    public void DestroySelf(){
    	Destroy(gameObject);
    }
}
