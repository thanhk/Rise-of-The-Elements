using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthBar;


    void Awake() 
    {
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = 100;
        healthBar.value = 100;
    }
    private void Start()
    {
     
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}