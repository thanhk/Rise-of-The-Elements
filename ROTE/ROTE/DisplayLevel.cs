 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 

 public class DisplayLevel : MonoBehaviour {
 
    Text txt;
    private int currentlevel=1;
 
    // Use this for initialization
    void Awake () {
        txt = gameObject.GetComponent<Text>(); 
        txt.text=currentlevel.ToString();
    }
     
    public void LevelUp()
    {
    	currentlevel++;
        txt.text = currentlevel.ToString();
    }

    public void SetLevel(int level)
    {
        currentlevel = level;
        txt.text = currentlevel.ToString();
    }
 }
