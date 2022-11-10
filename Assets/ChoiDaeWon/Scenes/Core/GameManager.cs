using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private int money;
    [SerializeField] private Slider hpBar;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private AudioDataSO audioData;

    [field:SerializeField] public float PlayerHP { get; set; }

    [HideInInspector] public Transform Player;
    [HideInInspector] public Camera Cam;
    

    public bool able { get; set; } = true;
    public bool isStart { get; set; }

    public int Money { get { return money; } set { money = value; } }

    public static GameManager instance;

    private Enemy[] enemy;

    private void Awake()
    {

        new AudioManager(audioData, gameObject);
        Cam = Camera.main;
        instance = this;
        Player = FindObjectOfType<Movement>().transform;
        hpBar.maxValue = PlayerHP;
        SaveManager saveManager = FindObjectOfType<SaveManager>();
        saveManager.SetSaveData();

        enemy = FindObjectsOfType<Enemy>();

        GameObject[] obj = GameObject.FindGameObjectsWithTag("Map");

        foreach(var o in obj)
        {

            o.gameObject.SetActive(false);

        }

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

        moneyText.text = Money.ToString();
        PlayerHP = Mathf.Clamp(PlayerHP, 0, 100);
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


        Rank rank = FindObjectOfType<Rank>();
        PlayerHP -= value;
        

        if(PlayerHP <= 0)
        {

            rank.SetRank();
            SetPlayerGunAble(false);
            SetPlayerMoveAble(false);
            Movement m = FindObjectOfType<Movement>();
            m.Die();

        }

    }

    public void ReloadAllEnemy()
    {

        foreach(var e in enemy)
        {

            e.gameObject.SetActive(true);

        }

    }

}
