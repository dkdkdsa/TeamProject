using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private int money;
    [SerializeField] private Slider hpBar;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private AudioDataSO audioData;
    [SerializeField] private UnityEvent hitEvent; 

    [field:SerializeField] public float PlayerHP { get; set; }

    [HideInInspector] public Transform Player;
    [HideInInspector] public Camera Cam;
    

    public bool able { get; set; } = true;
    public bool isStart { get; set; }

    public int Money { get { return money; } set { money = value; } }

    public static GameManager instance;

    private Enemy[] enemy;
    private CinemachineBasicMultiChannelPerlin cbmcp;
    private bool isShacke;

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

        cbmcp = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

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
        
        for(int j = 0; j < FindObjectOfType<Inventory>().weaponBullets.Length; j++)
        {

            SaveManager.instance.saveData.bulletSlots[j] = FindObjectOfType<Inventory>().weaponBullets[j].bullet;

        }

        for(int i = 0; i < FindObjectOfType<Inventory>().bulletSlots.Length; i++)
        {

            SaveManager.instance.saveData.bulletSlots[i] = FindObjectOfType<Inventory>().bulletSlots[i].isBuying;

        }

        FindObjectOfType<Potion>().Set();
        SaveManager.instance.Save();

    }

    public void SetAllObj()
    {

        Money = SaveManager.instance.saveData.money;

        for (int i = 0; i < FindObjectOfType<Inventory>().weaponBullets.Length; i++)
        {

            FindObjectOfType<Inventory>().weaponBullets[i].bullet = SaveManager.instance.saveData.weaponBulletSlots[i];

        }
        for (int i = 0; i < FindObjectOfType<Inventory>().bulletSlots.Length; i++)
        {

            FindObjectOfType<Inventory>().bulletSlots[i].isBuying = SaveManager.instance.saveData.bulletSlots[i];

        }

    }

    public void PlayerTakeDamage(float value)
    {


        Rank rank = FindObjectOfType<Rank>();
        PlayerHP -= value;
        hitEvent?.Invoke();

        if(PlayerHP <= 0)
        {

            rank.SetRank();
            SetPlayerGunAble(false);
            SetPlayerMoveAble(false);
            Movement m = FindObjectOfType<Movement>();
            m.Die();

        }

        if(isShacke == false)
        {

            StartCoroutine(PlayerDanageShakeCo());

        }

    }

    public void ReloadAllEnemy()
    {

        foreach(var e in enemy)
        {

            e.gameObject.SetActive(true);

        }

    }

    public void SetHp(float f)
    {

        PlayerHP = f;

    }

    public void SceneLoad(string sceneName)
    {

        try
        {

            Time.timeScale = 1;
            SceneManager.LoadScene(sceneName);

        }
        catch (Exception)
        {

            Debug.LogError($"{sceneName} 이라는 이름에 씬이 존재하는지 확인해주세요");

        }

    }

    public void ADDMoney(int i)
    {

        money += i;

    }

    IEnumerator PlayerDanageShakeCo()
    {

        isShacke = true;
        cbmcp.m_AmplitudeGain += 2f;
        cbmcp.m_FrequencyGain += 2f;
        yield return new WaitForSeconds(0.1f);
        cbmcp.m_AmplitudeGain -= 2f;
        cbmcp.m_FrequencyGain -= 2f;
        isShacke = false;
    }

    public void ResetShake()
    {
        
        cbmcp.m_AmplitudeGain = 0;
        cbmcp.m_FrequencyGain = 0;

    }

}
