using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<AllItems> _inventoryItems = new List<AllItems>(); //Our inventory items

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(AllItems item) //Add item to inventory
    {
        if (!_inventoryItems.Contains(item)) //Check if item is not already in inventory
        {
            _inventoryItems.Add(item);
        }
    }

    public void RemoveItem(AllItems item) //Remove item from inventory
    {
        if (_inventoryItems.Contains(item)) //Check if item is in inventory
        {
            _inventoryItems.Remove(item);
        }
    }

    public enum AllItems //All available inventory items in game
    {
        //Armas
        pistolaInicial,
        escopetaInicial,
        metralletaInicial,

        //Llaves
        llaveRosa,
        llaveTurquesa,
        llaveCafe,
        llaveNaranja,

        //Traje
        trajeInicial,
    }

    public enum Tokens
    {
        tokenMultidisparoDoble,
        tokenMultidisparoTriple,
        tokenMultidisparoCuadruple,
        tokenDisparoDoble,
        tokenDisparoTriple,
        tokenReboteBalas,
        tokenCombo,
        tokenAtaqueDirigido
    }

    public enum Pociones
    {
        pocionVelocidad,
        pocionEnergia,
        pocionSuperEnergia,
        pocionVida,
        pocionSuperVida,
        pocionInmunidad,
        pocionProteccion,
        pocionIman,
        pocionMystery
    }
}
