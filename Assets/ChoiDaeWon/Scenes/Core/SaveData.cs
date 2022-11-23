using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveData
{

    public int money;
    public List<BulletDataSO> weaponBulletSlots = new List<BulletDataSO>(3);
    public List<bool> bulletSlots = new List<bool>(6);
    public Potion potion;

}
