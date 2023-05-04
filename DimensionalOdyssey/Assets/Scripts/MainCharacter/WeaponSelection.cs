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
    [HideInInspector] public int idArma = 0;

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
                idArma = 1;
            }
            else if (HasRequiredItem(metralleta))
            {
                AsignarSprite(metralletaSprite);
                characterStats.AgregarPunto(0, 0, 0, 1f, 0, -5f);
                idArma = 2;
            }
            else if (HasRequiredItem(escopeta))
            {
                AsignarSprite(escopetaSprite);
                characterStats.AgregarPunto(0, 0, 0, -1.25f, -6, -2f);
                specialShot.UseMultiShot(true, 3, 60);
                basicShot.UseMultiShot(true, 3, 60);
                idArma = 3;
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
