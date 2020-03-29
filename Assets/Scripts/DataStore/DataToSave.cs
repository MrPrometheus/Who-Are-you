using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public enum EntityType { Wolf, Doctor};

public class DataToSave
{
    public List<int> levelTrustStatic;
    public List<int> dialogNumStatic;
    public DateTime lastSession; // дата последней сессии
    public DateTime gameStarted; // дата игра начата
    public DateTime dateTimeInGame;
    public string lastSceneName;
    public EntityType entityType; // wolf or doctor
    public Vector3 lastPostion;

    /// <summary>
    /// Создание нового файла статистики
    /// </summary>
    public DataToSave()
    {
        // default values
        Debug.Log("DischargeStatic");
        lastSession = DateTime.Now;
        gameStarted = DateTime.Now;
        dateTimeInGame = DateTime.Now;
        lastSceneName = SceneManager.GetActiveScene().name;
        lastPostion = new Vector3(0, 0, 0);
        entityType = EntityType.Doctor;
        levelTrustStatic = Enumerable.Repeat(0, 3).Select(n => { return 0; }).ToList();
        dialogNumStatic = Enumerable.Repeat(0, 3).Select(n => { return -1; }).ToList();
    }
}
