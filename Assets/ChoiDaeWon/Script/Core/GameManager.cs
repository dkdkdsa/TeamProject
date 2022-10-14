using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int money;
    [SerializeField] private Transform target;

    public int Money { get { return money; } set { money = value; } }

    public static GameManager instance;

    private void Awake()
    {
        
        instance = this;        

    }

    public void SetPlayerMoveAble(bool value)
    {

        Movement movement = FindObjectOfType<Movement>();
        movement.MoveAble = value;

    }

    public void SetPlayerGunAble(bool value)
    {

        Weapon weapon = FindObjectOfType<Weapon>();
        weapon.ShootAble = value;

    }

}
