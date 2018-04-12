using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Equipamento")]
public class Equipment : Item {

    public int damageModifier;
    public EquipmentSlot equipmentSlot;
    



    public override void Use()
    {
        base.Use();

        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipmentSlot { Arma, Armadura };