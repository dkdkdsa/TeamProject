#define Reset
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;
using UnityEngine.Events;
using System;

[System.Serializable]
public class EventList
{

    public BulletType bulletType;
    public int upgradeCount;
    public float[] extraDamage;
    public UnityEvent<Enemy>[] upgradeEvents;

}

public class Upgrader : MonoBehaviour
{

    public List<EventList> list = new List<EventList>();

    public static Upgrader instance;

    private void Awake()
    {
        
        instance = this;

        for(int i = 0; i < list.Count; i++)
        {

            try
            {

                list[i].upgradeCount = PlayerPrefs.GetInt(list[i].bulletType.ToString());

            }
            catch (Exception)
            {

                list[i].upgradeCount = 0;

            }


        }

    }

    private void Update()
    {

        Re();

    }

    public void UpgradeEvent(BulletType type, Enemy enemy)
    {

        for(int i = 0; i < list.Count; i++)
        {

            if(list[i].bulletType == type)
            {

                list[i].upgradeEvents[list[i].upgradeCount]?.Invoke(enemy);

                break;

            }

        }

    }

    public int FindUpGradeCount(BulletType type)
    {

        int n = 0;

        for(int i = 0; i < list.Count; i++)
        {

            if (list[i].bulletType == type)
            {

                n = list[i].upgradeCount;

                break;

            }

        }

        return n;

    }

    public float FindExtraDamage(BulletType type)
    {

        float value = 0;

        for (int i = 0; i < list.Count; i++)
        {

            if (list[i].bulletType == type)
            {

                value = list[i].extraDamage[list[i].upgradeCount];

                break;

            }

        }

        return value;

    }

    public bool UpGrade(BulletType type)
    {

        bool value = false;

        for(int i = 0; i < list.Count; i++)
        {

            if(list[i].bulletType == type)
            {

                if(list[i].upgradeEvents.Length > list[i].upgradeCount)
                {

                    list[i].upgradeCount++;
                    FindObjectOfType<Inventory>().GetBullet(list[i].bulletType);
                    value = true;

                }

            }

        }

        return value;

    }

    public bool ChackMaxUpgrade(BulletType type)
    {

        int n = 0;
        bool value = false;

        for (int i = 0; i < list.Count; i++)
        {

            if (list[i].bulletType == type)
            {

                n = list[i].upgradeCount;

                break;

            }

        }

        if(n >= 3)
        {

            value = true;

        }

        return value;

    }


    public void Save()
    {
        
        foreach(var a in list)
        {

            PlayerPrefs.SetInt(a.bulletType.ToString(), a.upgradeCount);

        }

    }

    public void Re()
    {

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.L))
        {
            foreach (var a in list)
            {

                PlayerPrefs.SetInt(a.bulletType.ToString(), 0);

            }
            for (int i = 0; i < list.Count; i++)
            {

                list[i].upgradeCount = 0;

            }
        }
#endif

    }

}
