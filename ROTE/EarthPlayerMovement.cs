using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPlayerMovement : MonoBehaviour
{


    public float moveSpeed = 5f;
    public float crosshairDist = 2f;
	public float arrowSpeed = 3f;

    public bool endOfAim;

    public Rigidbody2D rb;
    public Animator animator;
    public GameObject crosshair;
    Vector2 movement; //x and y position

	public Transform firePoint;
    public GameObject projectile;

    public GameObject arms;
    public Animator armAnimator;

    public GameObject weapon;
    public Animator wepAnimator;

    private Inventory inventory;
    [SerializeField] private InventoryUI inventoryUI = null;
    //public string playerID;

    public bool atk = false;
    
    void Start()
    {
        //playerID = System.Guid.NewGuid().ToString();
        //initialize inventory
        inventory = new Inventory(UseItem);
        inventoryUI.SetPlayer(this);
        inventoryUI.SetInventory(inventory);

        //get arm animator
        armAnimator = arms.GetComponent<Animator>();
        wepAnimator = weapon.GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        GetInput();
        Move();
        Aim();
        Shoot();
        
    }

    void FixedUpdate()
    {

        //movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Time.fixedDeltaTime smooths the player movement
        if(atk == true){
        	wepAnimator.SetBool("Attack", true);
        	armAnimator.SetBool("Attack", true);
        }else{
        	wepAnimator.SetBool("Attack", false);
        	armAnimator.SetBool("Attack", false);
        }
        atk = false;
    }

    void Move(){
    	movement.Normalize();
    	//updating the animator controller parameters
        //we can add a conditional statement here when we add more idle animations for different directions
    	if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            armAnimator.SetFloat("Horizontal", movement.x);
            armAnimator.SetFloat("Vertical", movement.y);
            wepAnimator.SetFloat("Horizontal", movement.x);
            wepAnimator.SetFloat("Vertical", movement.y);

        }
        animator.SetFloat("Magnitude", movement.magnitude);
        armAnimator.SetFloat("Magnitude", movement.magnitude);
        wepAnimator.SetFloat("Magnitude", movement.magnitude);
    }

    void GetInput()
    {
    	movement.x = Input.GetAxisRaw("Horizontal"); //returns a value between -1 and 1 (left and right)
        movement.y = Input.GetAxisRaw("Vertical"); //returns a value between -1 and 1 (down and up)
        endOfAim = Input.GetButtonUp("Fire1");
    }

    void Aim()
    {
        if(movement != Vector2.zero)
        {
            crosshair.transform.localPosition = movement * crosshairDist;
        }
    }

    void Shoot()
    {
        Vector2 shootDirection = crosshair.transform.localPosition; //shoot in direction of crosshair
        shootDirection.Normalize();

        if (endOfAim)
        {
        	atk = true;
        	
			GameObject bullet = Instantiate(projectile, firePoint.position, Quaternion.identity, gameObject.transform); //passes player Transform to bullet as parent
			Physics2D.IgnoreCollision(bullet.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>()); //ignores collision btwn bullet and player
			bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * arrowSpeed; //gives the bullet momentum
			bullet.transform.Rotate(0,0,Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg); //bullet direction
			
			Destroy(bullet, 2f);
        }

    }


    void OnTriggerEnter2D(Collider2D collider){

        //detect item triggers
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if(itemWorld != null){

            if(!inventory.isFull(itemWorld.GetItem())){
                Debug.Log("not full");
                inventory.AddItem(itemWorld.GetItem());
                itemWorld.DestroySelf();
            }
            
            Debug.Log(inventory.GetSize());
        }
    }

    void UseItem(Item item){
        switch(item.itemType){
            case Item.ItemType.RedPot:
            inventory.RemoveItem(new Item{itemType = Item.ItemType.RedPot, amount = 1});
                break;
            case Item.ItemType.BluePot:
            inventory.RemoveItem(new Item{itemType = Item.ItemType.BluePot, amount = 1});
                break;
        }
    }
}

