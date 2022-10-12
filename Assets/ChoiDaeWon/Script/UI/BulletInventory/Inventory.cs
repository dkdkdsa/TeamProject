using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField] private GameObject weaponBulletSlotParent;
    [SerializeField] private GameObject bulletSlotParent;
    [SerializeField] private BulletDataSO normalBullet;

    private Weapon weapon;
    private WeaponBulletSlot[] weaponBullets;
    private BulletSlot[] bulletSlots;

    private void Awake()
    {
        
        weapon = FindObjectOfType<Weapon>();
        weaponBullets = GetComponentsInChildren<WeaponBulletSlot>();
        bulletSlots = GetComponentsInChildren<BulletSlot>();

    }

    private void Start()
    {
        
        SetSlots();

    }

    private void Update()
    {

        for (int i = 0; i < weaponBullets.Length; i++)
        {

            weapon.SetBulletSlot(i, weaponBullets[i].bullet);

        }

    }

    private void SetSlots()
    {

        //세이브 만들면 만들기
        
        for(int i = 0; i < weaponBullets.Length; i++)
        {

            if(weaponBullets[i].bullet == null)
            {

                weapon.SetBulletSlot(i, normalBullet);
                weaponBullets[i].Set(normalBullet);
                bulletSlots[0].Set(normalBullet);

            }
            else
            {

                weapon.SetBulletSlot(i, weaponBullets[i].bullet);

            }

        }

        

    }

    public void GetBullet(BulletDataSO bulletDataSO)
    {

        for(int i = 0; i < bulletSlots.Length; i++)
        {

            if(bulletSlots[i].BulletData == null)
            {

                bulletSlots[i].Set(bulletDataSO);
                break;

            }

        }

    }


}
