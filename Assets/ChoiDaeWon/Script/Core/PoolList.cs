using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pools
{

    public string poolName;
    public GameObject poolObj;
    public int poolCount;

}

[CreateAssetMenu(menuName = "SO/PoolList")]
public class PoolList : ScriptableObject
{

    public List<Pools> pools = new List<Pools>();

}
