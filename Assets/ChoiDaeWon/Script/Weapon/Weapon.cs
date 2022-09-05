using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform firePos;

    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        SetAngle();
        RotateWeapon(angle > 90f || angle < -90);
        Shoot();

    }

    private void Shoot()
    {

        if (Input.GetMouseButtonDown(0))
        {

            cam.DOShakePosition(0.05f, new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)), 1000, 0);
            PoolManager.instance.Remove("Bullet", firePos.transform.position, Quaternion.Euler(0, 0, angle - 5));
            PoolManager.instance.Remove("Bullet", firePos.transform.position, Quaternion.Euler(0, 0, angle));
            PoolManager.instance.Remove("Bullet", firePos.transform.position, Quaternion.Euler(0, 0, angle + 5));

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


}
