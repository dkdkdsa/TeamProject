using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveData
{

    public int money;
    public WeaponBulletSlot[] weaponBulletSlots;
    public BulletSlot[] bulletSlots;
    public List<EventList> events;
    public Potion potion;

}
