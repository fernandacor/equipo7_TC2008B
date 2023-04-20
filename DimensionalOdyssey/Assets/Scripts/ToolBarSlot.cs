using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolBarSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");
        GameObject droppedItem = eventData.pointerDrag;
        ToolBarItem toolBarItem = droppedItem.GetComponent<ToolBarItem>();
        toolBarItem.parentAfterDrag = transform;
    }
}
