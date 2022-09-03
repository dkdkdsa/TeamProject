using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        SetAngle();

    }

    private void SetAngle()
    {

        Vector2 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        Vector2 aimpos = mousePos - (Vector2)transform.position;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        angle = Mathf.Atan2(aimpos.x, aimpos.y) * Mathf.Rad2Deg;

    }

}
