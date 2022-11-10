using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBossSkill : MonoBehaviour
{
    
    public void BossSkill(Transform skillPos)
    {

        for(int i = 0; i < 360; i += 10)
        {

            PoolManager.instance.Remove("FireBall", skillPos.position, Quaternion.Euler(new Vector3(0, 0, i)));

        }

    }

}
