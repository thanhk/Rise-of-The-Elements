using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public GameObject player;

    void Start(){
    	
        // need to assign player 
        // player = gameObject.transform.parent.gameObject; //player passed down through Instantiate call, transform parameter
    	//player = GameObject.FindGameObjectWithTag("Player");
    	//Physics2D.IgnoreCollision(player.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }

    void OnCollisionEnter2D(Collision2D collision){

    	if(collision.gameObject.tag == "Mob"){

            GameObject mob = collision.gameObject;
            
            int xp_drop = mob.GetComponent<Health>().DamageMonster(10);
            // gives player xp if monster is killed
            if (xp_drop > 0)
            {
                // player.gameObject.GetComponent<Experience>().GainExp(xp_drop);
            }
        }
		
    	GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    	Destroy(effect,5f);
    	Destroy(gameObject);
    }

}
