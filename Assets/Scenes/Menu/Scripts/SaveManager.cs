using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Zenject;

public class SaveManager
{
    public string FileName = "player_data";

    [Inject] private JSONSaver _JSONSaver;


    /// <summary>
    /// Сбросить все достижения
    /// </summary>
    public void Discharge()
    {
        DischargeStatic();
    }

    /// <summary>
    /// Cбросить статистику
    /// </summary>
    public void DischargeStatic()
    {
        Debug.Log("DischargeStatic");
        NPC.levelTrustStatic = Enumerable.Repeat(0, 3).Select(n => { return 0; }).ToList();
        NPC.dialogNumStatic = Enumerable.Repeat(0, 3).Select(n => { return -1; }).ToList();
        SaveStatic();
    }

    /// <summary>
    /// Сохранить ститистику
    /// </summary>
    public void SaveStatic()
    {
        DataToSave dataToSave = new DataToSave() { levelTrustStatic = NPC.levelTrustStatic, dialogNumStatic = NPC.dialogNumStatic };
        string data = JsonUtility.ToJson(dataToSave);
        Debug.Log("Load: " + data);
        _JSONSaver.WriteToFilestring(FileName, data);
    }

    /// <summary>
    /// Сохранить статистику
    /// </summary>
    public void Save()
    {
        SaveStatic();
    }

    /// <summary>
    /// Загрузить статитстику
    /// </summary>
    public void LoadStatic()
    {
        string data = _JSONSaver.ReadFromFile(FileName);
        Debug.Log("Load: "+ data);
        DataToSave dataToSave = JsonUtility.FromJson<DataToSave>(data);
        NPC.dialogNumStatic = dataToSave.dialogNumStatic;
        NPC.levelTrustStatic = dataToSave.dialogNumStatic;
    }

    /// <summary>
    /// Загрузить все сохранения
    /// </summary>
    public void Load()
    {
        LoadStatic();
    }
}


public class DataToSave
{
    public List<int> levelTrustStatic;
    public List<int> dialogNumStatic;
}