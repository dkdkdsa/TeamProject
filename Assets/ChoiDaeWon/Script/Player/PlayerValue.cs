using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValue : MonoBehaviour
{

    private int playerAttackPower = 10;

    public int  PlayerAttackPower
    {
        get { return Random.Range(playerAttackPower - 3, playerAttackPower + 3); }
        set { playerAttackPower = value; }
    }


}
