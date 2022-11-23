using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFX : MonoBehaviour
{

    [SerializeField] private AudioSource source;

    private float time;

    private void Update()
    {

        time += Time.deltaTime;

        if(time > 3)
        {

            time = 0;
            PoolManager.instance.Add(gameObject);

        }

    }

    public void Disable()
    {

        time = 0;
        PoolManager.instance.Add(gameObject);

    }

    private void OnEnable()
    {

        if (source == null) return;
        source.Play();

    }

}
