using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolBarSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData){
        Debug.Log("OnDrop");
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggbleItem = dropped.GetComponent<DraggableItem>();
        draggbleItem.parentAfterDrag = transform;
    } 
}
