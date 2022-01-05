using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float x = Input.GetAxis("Horizontal")*Time.deltaTime*40;
		float y = Input.GetAxis("Vertical")*Time.deltaTime*40;
		transform.Translate(x,y,0);
    }
}
