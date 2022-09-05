using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    [SerializeField] private PoolList poolList;
    private List<GameObject> poolObjs = new List<GameObject>();
    public static PoolManager instance;

    private void Awake()
    {

        instance = this;

        for (int i = 0; i < poolList.pools.Count; i++)
        {

            for (int j = 0; j < poolList.pools[i].poolCount; j++)
            {

                GameObject obj = Instantiate(poolList.pools[i].poolObj);
                obj.name = poolList.pools[i].poolName;
                obj.transform.SetParent(transform);
                obj.gameObject.SetActive(false);
                poolObjs.Add(obj);

            }
        }

    }

    public void Remove(string name, Vector2 pos, Quaternion rot)
    {

        bool value = false;

        for(int i = 0; i < poolObjs.Count; i++)
        {

            if(poolObjs[i].name == name && poolObjs[i].activeSelf == false)
            {

                value = true;
                GameObject obj = poolObjs[i].gameObject;
                obj.SetActive(true);
                obj.transform.SetPositionAndRotation(pos, rot);
                poolObjs.Remove(obj);
                break;

            }

        }

        if(value == false)
        {

            for(int i = 0; i < poolList.pools.Count; i++)
            {

                if(poolList.pools[i].poolName == name)
                {

                    GameObject _obj = Instantiate(poolList.pools[i].poolObj);
                    _obj.name = poolList.pools[i].poolName;
                    _obj.transform.SetParent(transform);
                    _obj.transform.SetPositionAndRotation(pos, rot);
                    _obj.gameObject.SetActive(true);

                }

            }

        }

    }

    public void Add(GameObject obj)
    {

        obj.gameObject.SetActive(false);
        poolObjs.Add(obj);

    }

}
