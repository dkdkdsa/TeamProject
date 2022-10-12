using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;
using UnityEngine.Events;

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
    [SerializeField] private List<EventList> list = new List<EventList>();

    public static Upgrader instance;

    private void Awake()
    {
        
        instance = this;

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
    
}
