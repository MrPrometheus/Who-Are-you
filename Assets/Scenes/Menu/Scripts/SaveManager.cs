using System;
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
    public DataToSave dataToSave;
    

    public bool isSaveDataExists()
    {
        return _JSONSaver.FileExists(FileName);
    }
    /// <summary>
    /// Сохранить ститистику
    /// </summary>
    public void SaveStatic()
    {
        //DataToSave dataToSave = new DataToSave() { levelTrustStatic = NPC.levelTrustStatic, dialogNumStatic = NPC.dialogNumStatic };
        string data = JsonUtility.ToJson(dataToSave);
        Debug.Log("Save: " + data);
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
        dataToSave = JsonUtility.FromJson<DataToSave>(data);
        //DataToSave dataToSave = JsonUtility.FromJson<DataToSave>(data);
        //NPC.dialogNumStatic = dataToSave.dialogNumStatic;
        //NPC.levelTrustStatic = dataToSave.dialogNumStatic;
    }
    /// <summary>
    /// Загрузить все сохранения
    /// </summary>
    public void Load()
    {
        LoadStatic();
    }

    /// <summary>
    /// Сбросить все достижения
    /// </summary>
    public void Discharge()
    {
        dataToSave = new DataToSave();
        SaveStatic();
    }
}