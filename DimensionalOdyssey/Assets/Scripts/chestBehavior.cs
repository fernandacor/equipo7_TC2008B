using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestBehavior : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite openChestSprite, closedChestSprite;
    private bool isOpen;

    public void Interact()
    {
        if(isOpen)
        {
            StopInteract();
        }
        else
        {
            spriteRenderer.sprite = openChestSprite;
            isOpen = true;
        }
        
    }

    public void StopInteract()
    {
        
    }
}
