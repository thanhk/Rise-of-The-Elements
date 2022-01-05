using UnityEngine;
using System.Collections;
 
public class Experience : MonoBehaviour 
{
 
    //current level
    public int vLevel = 1;
    //current exp amount
    public int vCurrExp = 0;
    //exp amount needed for lvl 1
    public int vExpBase = 10;
    //exp amount left to next levelup
    public int vExpLeft = 10;
    //modifier that increases needed exp each level
    public float vExpMod = 1.15f;
 	public DisplayLevel displayLevel;

 
    //leveling methods
    public void GainExp(int e)
    {
        vCurrExp += e;
        while(vCurrExp >= vExpLeft)
        {
            LvlUp();
        }
    }

    public void SetLevel(int level)
    {
        vLevel = level;
        displayLevel.SetLevel(level); 
    }
    void LvlUp()
    {
    	displayLevel.LevelUp();
        vCurrExp -= vExpLeft;
        vLevel++;
        float t = Mathf.Pow(vExpMod, vLevel);
        vExpLeft = (int)Mathf.Floor(vExpBase * t);
    }
    public int GetPercentXP()
    {
        return (int)(100 * vCurrExp/vExpBase);
    }
}
