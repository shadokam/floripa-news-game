using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {


    #region Singleton
    public static EquipmentManager instance;

    void Awake()
    {
        instance = this; 
    }
    #endregion

    Equipment[] currentEquipment;

    void Start()
    {
        int slotNumber = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[slotNumber];
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipmentSlot;
        currentEquipment[slotIndex] = newItem;
    }
}
