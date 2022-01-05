// Initializes the target variable.
// target is private and thus not editable in the Inspector

// The ExampleClass starts with Awake.  The GameObject class has activeSelf
// set to false.  When activeSelf is set to true the Start() and Update()
// functions will be called causing the ExampleClass to run.
// Note that ExampleClass (Script) in the Inspector is turned off.  It
// needs to be ticked to make script call Start.

using UnityEngine;
using SystemRandom = System.Random;
using System.Collections;
using System.Collections.Generic;

public class MobSpawner : MonoBehaviour
{
    public GameObject earthMob1;
    private SystemRandom rand;
    private GameObject player;
    Dictionary<string, int> mobCounter;
    Dictionary<string, int> mobCap;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rand = new SystemRandom();
        mobCounter = new Dictionary<string, int>();
        mobCap = new Dictionary<string, int>();
        mobCounter.Add("earthMob1", 0);
        mobCap.Add("earthMob1", 10);
    }

    // IEnumerator Start()
    // {
    //     Debug.Log("Start1");
    //     yield return new WaitForSeconds(2.5f);
    //     Debug.Log("Start2");
    // }

    void Update()
    {
        if (mobCounter["earthMob1"] < mobCap["earthMob1"] && rand.Next(1,300) == 69){
        	SpawnEarthMob1(player.transform.position + new Vector3(rand.Next(-10,10), rand.Next(-10,10), 0));
        }
    }

    private void SpawnEarthMob1(Vector3 position)
    {
        GameObject monster = Instantiate(earthMob1, position, Quaternion.identity);
        int level = rand.Next(1,10);
    	int health = level * 20;
    	int attack = 1;
    	monster.GetComponent<Monster>().SetStats(level, health, attack, "earthMob1");
        mobCounter["earthMob1"]++;
    }

    public void MobDestroyed(string mobType){
    	if (mobCounter.ContainsKey(mobType))
    		mobCounter[mobType]--;
    	else
    		print(mobType + " does not exist!");
    }
}