using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script para definir los items del inventario

public class InventoryManager : MonoBehaviour
{
    // 
    public static InventoryManager Instance;

    public List<AllItems> _inventoryItems = new List<AllItems>(); // Referencia a la lista de todos los items del inventario

    private void Awake()
    {
        Instance = this;
    }

    // Función para añadir items al inventario
    public void AddItem(AllItems item)
    {
        if (!_inventoryItems.Contains(item)) // Checar si el item no está en el inventario
        {
            _inventoryItems.Add(item);
        }
    }

    // Función para quitar items del inventario
    public void RemoveItem(AllItems item)
    {
        if (_inventoryItems.Contains(item)) //Checar si el item está en el inventario
        {
            _inventoryItems.Remove(item);
        }
    }

    // Lista de todos los items que pueden estar en el inventario
    public enum AllItems
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
        llaveOficina,
        llaveBanco,
        llavePolicias,

        //Traje
        trajeInicial,

        //Tokens
        tokenMultidisparoDoble,
        tokenMultidisparoTriple,
        tokenMultidisparoCuadruple,
        tokenDisparoDoble,
        tokenDisparoTriple,
        tokenPowerShot,
        tokenReboteBalas,
        tokenCombo,
        tokenAtaqueDirigido,

        //Pociones
        pocionVelocidad,
        pocionEnergia,
        pocionSuperEnergia,
        pocionVida,
        pocionSuperVida,
        pocionResistencia,
        pocionFuerza,
        pocionIman,
        pocionMystery,
        xpBoost
    }

    // Lista individual de los tokens
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

    // Lista individual de las pociones
    public enum Pociones
    {
        pocionVelocidad,
        pocionEnergia,
        pocionSuperEnergia,
        pocionVida,
        pocionSuperVida,
        pocionResistencia,
        pocionFuerza,
        pocionIman,
        pocionMystery,
        xpBoost
    }

    // Lista individual de las llaves
    public enum Llaves
    {
        llaveRosa,
        llaveTurquesa,
        llaveCafe,
        llaveNaranja,
        llaveOficina,
        llaveBanco,
        llavePolicias
    }
}
