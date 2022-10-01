using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int money;

    public int Money { get { return money; } set { money = value; } }

    public static GameManager instance;

    private void Awake()
    {
        
        instance = this;

    }

}
