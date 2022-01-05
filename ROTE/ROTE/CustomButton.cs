using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

#pragma warning disable 0649
    [SerializeField]
    private float reqHoldTime;
    
    [SerializeField]
    private Image fillImage;
#pragma warning restore 0649

    public UnityEvent onLongClick;



    public void OnPointerDown(PointerEventData eventData){
    	pointerDown = true;
    	Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData){
    	Reset();
    	Debug.Log("OnPointerUp");
    }

    private void Update()
    {
    	if(pointerDown){
    		pointerDownTimer += Time.deltaTime;
    		if(pointerDownTimer >= reqHoldTime){
    			if(onLongClick != null){
    				onLongClick.Invoke();
    			}
    			Reset();
    		}
    		fillImage.fillAmount = pointerDownTimer / reqHoldTime;
    	}
    }

    private void Reset()
    {
    	pointerDown = false;
    	pointerDownTimer = 0;
    	fillImage.fillAmount = pointerDownTimer / reqHoldTime;
    }


}
