using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using Cinemachine.Editor;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform firePos;
    [SerializeField] private BulletDataSO[] slot;
    [SerializeField] private float shootingDelay;
    [SerializeField] private GameObject fireLight;
    [SerializeField] private CinemachineVirtualCamera cvcam;

    private CinemachineBasicMultiChannelPerlin cbmcp;
    private int currentAmmo = 18;
    private float angle;
    private bool isDelay;

    public bool isReload;
    public string ammoText = "Ammo";

    public int CurrentAmmo => currentAmmo;

    public bool ShootAble { get; set; }

    private void Awake()
    {

        cbmcp = cvcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        ammoText = "Ammo";
        ShootAble = true;

    }

    private void Update()
    {

        if (GameManager.instance.able == false) return;

        if(ShootAble == true)
        {

            SetAngle();
            RotateWeapon(angle > 90f || angle < -90);
            Shoot();

        }


    }

    private void Shoot()
    {

        bool value = Input.GetMouseButtonDown(0) && isDelay == false && currentAmmo != 0 && isReload == false;

        if(value)
        {

            StartCoroutine(FireShackCo());

            //cam.DOShakePosition(0.05f, new Vector2(Random.Range(-5f, 5f), Random.Range(-3, 3)), 1000, 0);
            AudioManager.instance.Play("Fire");
            PoolManager.instance.Remove(slot[0].bulletObj.gameObject.name, firePos.transform.position, Quaternion.Euler(0, 0, angle - 5));
            PoolManager.instance.Remove(slot[1].bulletObj.gameObject.name, firePos.transform.position, Quaternion.Euler(0, 0, angle));
            PoolManager.instance.Remove(slot[2].bulletObj.gameObject.name, firePos.transform.position, Quaternion.Euler(0, 0, angle + 5));
            StartCoroutine(ShootDelay(shootingDelay));
            StartCoroutine(FireLightCo());
            currentAmmo -= 3;

        }

    }

    public void Reload()
    {

        if(isReload == false && currentAmmo != 18)
        {

            isReload = true;
            ammoText = "Reload";
            AudioManager.instance.Play("Reload");
            StartCoroutine(ReLoadCO());

        }

    }

    private void SetAngle()
    {

        Vector2 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        Vector2 aimpos = mousePos - (Vector2)transform.position;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        angle = Mathf.Atan2(aimpos.y, aimpos.x) * Mathf.Rad2Deg;

    }

    private void RotateWeapon(bool value)
    {

        Vector3 localScale = Vector3.one;
        if (value == true) localScale.y = -1;

        transform.localScale = localScale;

    }

    public void SetBulletSlot(int num, BulletDataSO bullet)
    {

        num = Mathf.Clamp(num, 0, 2);

        slot[num] = bullet;

    }

    IEnumerator FireLightCo()
    {

        fireLight.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        fireLight.gameObject.SetActive(false);

    }
    IEnumerator ShootDelay(float shootingDelay)
    {

        isDelay = true;
        yield return new WaitForSeconds(shootingDelay);
        isDelay = false;

    }
    IEnumerator ReLoadCO()
    {

        yield return null;

        while(currentAmmo != 18)
        {

            currentAmmo++;
            yield return new WaitForSeconds(0.05f);
 
        }

        isReload = false;
        ammoText = "Ammo";

    }
    IEnumerator FireShackCo()
    {

        yield return null;

        cbmcp.m_AmplitudeGain = 1f;
        cbmcp.m_FrequencyGain = 0.7f;

        yield return new WaitForSeconds(0.2f);

        cbmcp.m_AmplitudeGain = 0;
        cbmcp.m_FrequencyGain = 0;
    }

}
