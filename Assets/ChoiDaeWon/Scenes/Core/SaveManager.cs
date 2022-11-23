using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor.Purchasing;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    public SaveData saveData;

    public static SaveManager instance;

    public void SetSaveData()
    {

        instance = this;

        if (File.Exists(@"C:\\Users\\user\\Documents\\GGMTPJ104") == false)
        {

            Directory.CreateDirectory(@"C:\\Users\\user\\Documents\\GGMTPJ104");

        }
        if (File.Exists(@"C:\\Users\\user\\Documents\\GGMTPJ104\\SaveData.json") == false)
        {

            File.Create(@"C:\\Users\\user\\Documents\\GGMTPJ104\\SaveData.json");
            File.Create(@"C:\\Users\\user\\Documents\\GGMTPJ104\\ErrorLog.json");
            GameManager.instance.isStart = true;

        }
        else
        {

            Read();
            GameManager.instance.SetAllObj();

        }


    }

    public void Save()
    {

        string jsonValue = JsonUtility.ToJson(saveData);
        Debug.Log(jsonValue);
        File.WriteAllText(@"C:\\Users\\user\\Documents\\GGMTPJ104\\SaveData.json", jsonValue);

    }

    public void Save<T>(T obj)
    {

        string jsonValue = JsonUtility.ToJson(obj);
        File.WriteAllText(@"C:\\Users\\user\\Documents\\GGMTPJ104\\ErrorLog.json", jsonValue);

    }

    private void Read()
    {

        string jsonValue = File.ReadAllText(@"C:\\Users\\user\\Documents\\GGMTPJ104\\SaveData.json");
        saveData = JsonUtility.FromJson<SaveData>(jsonValue);        

    }

    public T Read<T>()
    {

        string jsonValue = File.ReadAllText(@"C:\\Users\\user\\Documents\\GGMTPJ104\\ErrorLog.json");
        return JsonUtility.FromJson<T>(jsonValue);

    }

}
