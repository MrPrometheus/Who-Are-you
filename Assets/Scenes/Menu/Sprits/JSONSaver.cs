using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class JSONSaver : MonoBehaviour
{
    public static string FileName = "player";
    public static string prefix = ".txt";
    

    public void Discharge()
    {
        DischargeStatic();
    }
    public static void DischargeStatic()
    {
        NPC.levelTrustStatic = Enumerable.Repeat(0, 3).Select(n => { return 0; }).ToList();
        NPC.dialogNumStatic = Enumerable.Repeat(0, 3).Select(n => { return -1; }).ToList();
        SaveStatic();
    }
    public static void SaveStatic()
    {
        DataToSave dataToSave = new DataToSave() { levelTrustStatic = NPC.levelTrustStatic, dialogNumStatic = NPC.dialogNumStatic };
        string data = JsonUtility.ToJson(dataToSave);
        WriteToFilestring(FileName, data);
    }
    public void Save()
    {
        SaveStatic();
    }
    public static void LoadStatic()
    {
        string data = ReadFromFile(FileName);
        DataToSave dataToSave = JsonUtility.FromJson<DataToSave>(data);
        NPC.dialogNumStatic = dataToSave.dialogNumStatic;
        NPC.levelTrustStatic = dataToSave.levelTrustStatic;
    }
    public void Load()
    {
        LoadStatic();
    }
    private static void WriteToFilestring(string fileName, string data)
    {
        string path =  GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter streamWriter = new StreamWriter(fileStream))
        {
            streamWriter.Write(data);
        }

    }
    private static string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
        else
            Debug.Log("file not found");
        return "";
    }
    private static string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName + prefix;
    }

    
}

class DataToSave
{
    public List<int> levelTrustStatic;
    public List<int> dialogNumStatic;
}