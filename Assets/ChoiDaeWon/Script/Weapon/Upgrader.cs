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
    public float extraDamage;
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
    
}
