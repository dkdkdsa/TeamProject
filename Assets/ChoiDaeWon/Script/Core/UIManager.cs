using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Image pauseImage;
    [SerializeField] private GameObject bulletInventoryImage;
    [SerializeField] private TextMeshProUGUI ammoText;

    private Weapon weapon;
    private bool isAnyOpen;
    private bool isInventoryOpening;

    public static UIManager instance;

    private void Awake()
    {
        
        weapon = FindObjectOfType<Weapon>();
        instance = this;

    }

    private void Update()
    {

        AmmoCountUI();

    }


    private void BulletInventoryOpen()
    {

        Sequence sequence = DOTween.Sequence();
        sequence
        .OnStart(() => 
        {

            isInventoryOpening = true;

        })
        .Append(bulletInventoryImage.transform.DOLocalMove(Vector2.zero, 0.5f)).SetEase(Ease.OutBounce)
        .OnComplete(() =>
        { 
        
            isInventoryOpening = false;

        });
        isAnyOpen = true;

    }

    private void BulletInventoryClose()
    {

        Sequence sequence = DOTween.Sequence();
        sequence
        .OnStart(() => 
        {

            isInventoryOpening = true;

        })
        .Append(bulletInventoryImage.transform.DOLocalMove(new Vector2(0, -1100), 0.5f)).SetEase(Ease.OutBounce)
        .OnComplete(() =>
        { 
        
            isInventoryOpening = false;

        });
        isAnyOpen= false;

    }

    private void AmmoCountUI()
    {

        ammoText.text = $"{weapon.ammoText} : {weapon.CurrentAmmo}/18";

    }
    public void TryBulletInventoryStateChange(float value)
    {

        if (isAnyOpen && value == -0.1f && isInventoryOpening == false) BulletInventoryClose();
        else if(isInventoryOpening == false && value == 0.1f) BulletInventoryOpen();

    }

    public void PauseUIOpenAndClouse()
    {

        pauseImage.gameObject.SetActive(!pauseImage.gameObject.activeSelf);

        if(pauseImage.gameObject.activeSelf == true)
        {

            DOTween.KillAll();
            GameManager.instance.able = false;
            Time.timeScale = 0;

        }
        else
        {

            GameManager.instance.able = true;
            Time.timeScale = 1;

        }

    }

}
