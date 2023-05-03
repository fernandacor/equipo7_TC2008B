using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSprite : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems pistola, metralleta, escopeta;
    public Sprite pistolaSprite;
    public Sprite metralletaSprite;
    public Sprite escopetaSprite;
    private bool seHaEjecutado = false;

    void Update()
    {
        if (!seHaEjecutado)
        {
            if (HasRequiredItem(pistola))
            {
                AsignarSprite(pistolaSprite);
            }
            else if (HasRequiredItem(metralleta))
            {
                AsignarSprite(metralletaSprite);
            }
            else if (HasRequiredItem(escopeta))
            {
                AsignarSprite(escopetaSprite);
            }
        }
    }

    public void AsignarSprite(Sprite mySprite)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = mySprite;
        seHaEjecutado = true;
    }

    bool HasRequiredItem(InventoryManager.AllItems reqItem)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(reqItem))
            return true;
        else
            return false;
    }
}
