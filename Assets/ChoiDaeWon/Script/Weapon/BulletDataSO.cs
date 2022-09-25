using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumTypes;

[CreateAssetMenu(menuName = "SO/BulletData")]
public class BulletDataSO : ScriptableObject
{

    public Sprite bulletSprite;
    public GameObject bulletObj;
    public BulletType bulletType;
    public float bulletExtraDamage;

}
