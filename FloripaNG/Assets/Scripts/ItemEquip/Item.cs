using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Item", menuName = "Inventário")]
public class Item : ScriptableObject {

    new public string name = "Nome do item";
    public Sprite icon = null;
    public bool isDefault = false;


    public virtual void Use()
    {
        //Usar item

        Debug.Log("Usando " + name);
    }


    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
