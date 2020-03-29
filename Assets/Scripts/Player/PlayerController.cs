using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class PlayerController : MonoBehaviour
{    
    public static GameObject currntActive;

    [Inject] private SaveManager _saveManager;

    public  Transform[] WolfPointsGeneration;
    private GameObject  doctor;
    private GameObject  wolf;
    private Vector2     tpPosition;


    void Awake()
    {
        DayController.DayHasCome += DayControllerOnDayHasCome;
        DayController.NightHasCome += DayControllerOnNightHasCome;
        
        doctor = transform.GetChild(0).gameObject;
        wolf = transform.GetChild(1).gameObject;
        currntActive = doctor;
        Door.ChangePosition += Door_ChangePosition;
    }

    private void OnDestroy()
    {
        _saveManager.dataToSave.lastPostion = doctor.active ? doctor.transform.position : wolf.transform.position;
        _saveManager.dataToSave.lastSceneName = SceneManager.GetActiveScene().name;
        _saveManager.dataToSave.lastSession = DateTime.Now;
        _saveManager.Save();
        Door.ChangePosition -= Door_ChangePosition;
    }

    private void Door_ChangePosition(Vector2 vector)
    {
        tpPosition = vector;
        if (tpPosition != Vector2.zero) doctor.transform.position = tpPosition;
        Door.ChangePosition -= Door_ChangePosition;
    }

    private void DayControllerOnNightHasCome()
    {
        if (!doctor || !wolf) return;
        doctor.SetActive(false);
        wolf.SetActive(true);
        currntActive = wolf;
        // ставим волку случайную позицию из предложенных
        int position_num = UnityEngine.Random.Range(0, WolfPointsGeneration.Length);
        wolf.transform.position = WolfPointsGeneration[position_num].position;
    }

    private void DayControllerOnDayHasCome()
    {
        if (!doctor || !wolf) return;
        doctor.SetActive(true);
        wolf.SetActive(false);
        currntActive = doctor;
    }
}
