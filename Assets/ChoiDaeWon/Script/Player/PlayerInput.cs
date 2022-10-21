using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        Pause();

    }

    private void ShopUIDisable()
    {

        if (Input.GetKeyDown(KeyCode.Q))
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

    private void Pause()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            UIManager.instance.PauseUIOpenAndClouse();

        }

    }

}
