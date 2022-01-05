using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
	private RectTransform rectTransform;

	private void Start(){
		rectTransform = GetComponent<RectTransform>();
	}
	public void OnDrag(PointerEventData eventData){
		transform.position = Input.mousePosition;
	}

	public void OnEndDrag(PointerEventData eventData){
		//transform.localPosition = Vector3.zero;
	}
    
    public void OnPointerDown(PointerEventData eventData){

    }
}
