using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private int money;
    [SerializeField] private Slider hpBar;

    [field:SerializeField] public float PlayerHP { get; set; }

    [HideInInspector] public Transform Player;
    [HideInInspector] public Camera Cam;
    

    public bool able { get; set; } = true;
    public bool isStart { get; set; }

    public int Money { get { return money; } set { money = value; } }

    public static GameManager instance;

    private void Awake()
    {
        
        Cam = Camera.main;
        instance = this;
        Player = FindObjectOfType<Movement>().transform;
        hpBar.maxValue = PlayerHP;
        SaveManager saveManager = FindObjectOfType<SaveManager>();
        saveManager.SetSaveData();

    }

    private void Start()
    {
        
        if(isStart == true)
        {

            Save();

        }

    }

    private void Update()
    {
        
        hpBar.value = PlayerHP;

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

    public void Save()
    {

        SaveManager.instance.saveData.money = Money;
        SaveManager.instance.saveData.weaponBulletSlots = FindObjectOfType<Inventory>().weaponBullets;
        SaveManager.instance.saveData.bulletSlots = FindObjectOfType<Inventory>().bulletSlots;
        SaveManager.instance.saveData.events = FindObjectOfType<Upgrader>().list;
        SaveManager.instance.Save();

    }

    public void SetAllObj()
    {

        Money = SaveManager.instance.saveData.money;
        FindObjectOfType<Inventory>().weaponBullets = SaveManager.instance.saveData.weaponBulletSlots;
        FindObjectOfType<Inventory>().bulletSlots = SaveManager.instance.saveData.bulletSlots;
        FindObjectOfType<Upgrader>().list = SaveManager.instance.saveData.events;

    }

    public void PlayerTakeDamage(float value)
    {


        PlayerHP -= value;

        if(PlayerHP <= 0)
        {

            //죽는거 만들기

        }

    }

}
