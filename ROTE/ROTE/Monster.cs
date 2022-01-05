using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
	// Monster stats
	public int _level;
	public int _health;
	public int _attack;
	public int _xpDrop;
	public string _mobType;

	public Animator animator;

	private bool _isAlive;
    // Start is called before the first frame update
    void Awake()
    {
    	_isAlive = true;
        _level = 1;
        _health = 100;
        _attack = 0;
        _xpDrop = 1;
        _mobType = "Unknown";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStats(int level, int health, int attack, string mobType, int currentHealth = -1, int xpDrop = -1){
    	_level = level;
    	_health = health;
    	_attack = attack;
    	_mobType = mobType;
    	// print(_level);
    	if (currentHealth == -1)
    		currentHealth = health;
    	// print("stats set for monster");
    	gameObject.GetComponent<Health>().SetHealth(health, currentHealth);
    	gameObject.GetComponent<Experience>().SetLevel(level);
    	if (xpDrop == -1)
    	{
    		// default xp drop
    		_xpDrop = level * health * attack;
    	} 
    	else 
    		_xpDrop = xpDrop;
    }

    public int Die(){
    	if (_isAlive){
    		animator.SetBool("isDead", true);
    		// finds mob spawner and notifies it
	    	var MobSpawner = GameObject.Find("MobSpawner").GetComponent<MobSpawner>();
	    	MobSpawner.MobDestroyed(_mobType);
	    	_isAlive = false;
	    	Destroy(gameObject,1f);
    	}
    	
    	return _xpDrop;
    }
}
