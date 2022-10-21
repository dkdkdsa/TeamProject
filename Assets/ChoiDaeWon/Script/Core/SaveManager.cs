using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    public SaveData saveData;

    public static SaveManager instance;

    private void Awake()
    {



    }

    public void SetSaveData()
    {

        instance = this;

        if (File.Exists(@"C:\\Users\\user\\Documents\\GGMTPJ104") == false)
        {

            Directory.CreateDirectory(@"C:\\Users\\user\\Documents\\GGMTPJ104");

        }
        if (File.Exists(@"C:\\Users\\user\\Documents\\GGMTPJ104\\SaveData.json") == false)
        {

            File.Create(@"C:\\Users\\user\\Documents\\GGMTPJ104\\SaveData.txt");

        }

        Read();

        //나중에 주석 풀어라 꼭 
        //GameManager.instance.SetAllObj();

    }

    public void Save()
    {

        string jsonValue = JsonUtility.ToJson(saveData);
        Debug.Log(jsonValue);
        File.WriteAllText(@"C:\\Users\\user\\Documents\\GGMTPJ104\\SaveData.json", jsonValue);

    }

    private void Read()
    {

        string jsonValue = File.ReadAllText(@"C:\\Users\\user\\Documents\\GGMTPJ104\\SaveData.json");
        saveData = JsonUtility.FromJson<SaveData>(jsonValue);
        

    }

}
