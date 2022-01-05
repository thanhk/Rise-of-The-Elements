using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int _curHealth = 0;
    public int _maxHealth = 100;

    public HealthBar healthBar;

    

    // Start is called before the first frame update
    void Start()
    {
        _curHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    	// 
    }

    public void SetHealth(int maxHealth, int curHealth = -1)
    {
        if (curHealth == -1)
            curHealth = maxHealth;
        _maxHealth = maxHealth;
        _curHealth = curHealth;
        healthBar.SetHealth( 100 * _curHealth/_maxHealth);
    }

    public int GetCurrentHealth()
    {
        return _curHealth;
    }

    public int DamageMonster(int damage)
    {
        _curHealth -= damage;
        // this health only works for monsters
        if(_curHealth <= 0){
    		var xpDrop = gameObject.GetComponent<Monster>().Die();
            return xpDrop;
		}

        healthBar.SetHealth( 100 * _curHealth/_maxHealth );
        return 0;
    }
}