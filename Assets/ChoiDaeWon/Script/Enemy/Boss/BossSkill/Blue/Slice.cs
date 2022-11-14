using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Slice : MonoBehaviour
{

    [SerializeField] private GameObject baseObj;
    [SerializeField] private GameObject waringObj;
    [SerializeField] private GameObject sliceObj;
    [SerializeField] private AudioSource source;


    public void Spawn()
    {

        source.Play();
        baseObj.transform.DOScaleY(1, 0.15f);

    }

    public void OnSlice()
    {

        waringObj.SetActive(false);
        sliceObj.SetActive(true);

        bool value = Physics2D.BoxCast(transform.position, new Vector2(0.1f, 70f), transform.eulerAngles.z, Vector2.zero, 0, LayerMask.GetMask("Player"));

        if (value)
        {

            GameManager.instance.PlayerTakeDamage(30f);

        }

    }

    public void DeSpawn()
    {

        baseObj.transform.DOScaleY(0, 0.15f)
        .OnComplete(() =>
        {

            PoolManager.instance.Add(gameObject);

        });

    }

    private void OnDisable()
    {


        waringObj.SetActive(true);
        sliceObj.SetActive(false);

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        
        Gizmos.DrawWireCube(transform.position, new Vector3(0.1f, 70f, 0f));

    }

#endif

}
