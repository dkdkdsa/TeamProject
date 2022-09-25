using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private Weapon weapon;
    private ShopShow shopShow;

    public KeyCode reloadKey;

    private void Awake()
    {
        
        weapon = FindObjectOfType<Weapon>();
        shopShow = FindObjectOfType<ShopShow>();

    }

    void Update()
    {

        OpenBulletInventory();
        Reload();
        ShopUIDisable();

    }

    private void ShopUIDisable()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            shopShow.Disable();

        }

    }

    private void OpenBulletInventory()
    {

        //0, 0.1, -0.1 
        float value = Input.GetAxisRaw("Mouse ScrollWheel");

        if (value != 0)
        {

            UIManager.instance.TryBulletInventoryStateChange(value);

        }

    }

    private void Reload()
    {

        if (Input.GetKeyDown(reloadKey))
        {

            weapon.Reload();

        }

    }

}
