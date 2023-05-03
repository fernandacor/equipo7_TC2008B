using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSelection : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems pistola, metralleta, escopeta;
    public Sprite pistolaSprite;
    public Sprite metralletaSprite;
    public Sprite escopetaSprite;
    private bool seHaEjecutado = false;
    private CharacterStats characterStats;
    private SpecialShot specialShot;
    private BasicShot basicShot;

    void Start()
    {
        characterStats = transform.parent.GetComponent<CharacterStats>();
        specialShot = GetComponent<SpecialShot>();
        basicShot = GetComponent<BasicShot>();
    }

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
                characterStats.AgregarPunto(0, 0, 0, 0.35f, 0, -1.5f);
            }
            else if (HasRequiredItem(escopeta))
            {
                AsignarSprite(escopetaSprite);
                characterStats.AgregarPunto(0, 0, 0, -2.5f, -3, 6);
                specialShot.UseMultiShot(true, 3, 90);
                basicShot.UseMultiShot(true, 3, 90);
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
