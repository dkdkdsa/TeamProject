using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{

    [SerializeField] private int shakePower;
    [SerializeField] private float duration;
    [SerializeField] private Vector2 dir;

    private Camera cam;

    private void Awake()
    {
        
        cam = FindObjectOfType<Camera>();

    }

    public void Load()
    {

        cam.DOShakePosition(duration, dir, shakePower, 0f);

    }

}
