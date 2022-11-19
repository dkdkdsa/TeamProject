using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageClearManaging : MonoBehaviour
{

    [SerializeField] private UnityEvent clearEvent;

    private Enemy[] managingObjects;
    private bool isClear;

    private void Update()
    {

        if (isClear) return;

        int mCount = 0;

        foreach(var m in managingObjects)
        {

            if(m.transform.gameObject.activeSelf == false)
            {

                mCount += 1;

            }

        }

        if(mCount == managingObjects.Length)
        {

            isClear = true;
            clearEvent?.Invoke();

        }

    }

    private void OnDisable()
    {

        isClear = false;

    }

    private void OnEnable()
    {

        if (managingObjects == null)
        {

            managingObjects = GetComponentsInChildren<Enemy>();

        }

        Debug.Log(1);

        foreach (var m in managingObjects)
        {

            if (m.transform.gameObject.activeSelf == false)
            {

                m.gameObject.SetActive(true);

            }

        }

    }

}
