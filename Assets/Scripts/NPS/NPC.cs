using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class NPC : MonoBehaviour
{
    public string Name;
    public Sprite head;
    public Employee Proffesion;

    public static DialogController controller;

    private DialogSet[] dialogSets;
    private GameObject buttonToDialog;
    private ClickController cloud;
    private NpsAIRandomWalking randomWalking;

    public static List<int> levelTrustStatic =  Enumerable.Repeat(0, 3).Select(n => { return 0; }).ToList();
    public static List<int> dialogNumStatic = Enumerable.Repeat(0, 3).Select(n => { return -1; }).ToList();

    private int LevelTrust = 0;
    private int dialogNum = -1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            cloud.LightingCloud();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            cloud.BlackoutCloud(); ;
    }

    private void Start()
    {
        LevelTrust = levelTrustStatic[(int)Proffesion];
        dialogNum = dialogNumStatic[(int)Proffesion];
        dialogSets = DialogData.instance.GetDialogSet(Proffesion);
        DayController.DayHasCome += DayController_DayHasCome;
        DayController.NightHasCome += DayController_NightHasCome;
        buttonToDialog = transform.GetChild(0).gameObject;
        cloud = buttonToDialog.GetComponent<ClickController>();
        randomWalking = GetComponent<NpsAIRandomWalking>();
        if (dialogSets != null)
        {
            if (dialogNum + 1 == dialogSets[LevelTrust].Dialogs.Length)
            {
                if (LevelTrust == dialogSets.Length - 1) buttonToDialog.SetActive(false);
            }
        }
        else cloud.gameObject.SetActive(false);

    }

    private void OnDestroy()
    {
        SaveProgress();
        DayController.DayHasCome -= DayController_DayHasCome;
        DayController.NightHasCome -= DayController_NightHasCome;
    }
    private void SaveProgress()
    {
        Debug.Log("сохраняем");
        levelTrustStatic[(int)Proffesion] = LevelTrust;
        dialogNumStatic[(int)Proffesion] = dialogNum;
        JSONSaver.SaveStatic();
    }

    private void DayController_NightHasCome()
    {
        buttonToDialog.SetActive(false);
    }

    private void DayController_DayHasCome()
    {
        buttonToDialog.SetActive(true);
    }

    public void StartDialog()
    {
        dialogNum++;
        controller.EndDialog += EndDialogEventReciever;
        if (dialogNum == dialogSets[LevelTrust].Dialogs.Length)
        {
            dialogNum = 0;
            if (LevelTrust != dialogSets.Length - 1) LevelTrust++;
        }
        if (randomWalking != null) randomWalking.isWorking = false;
        buttonToDialog.SetActive(false);
        controller.StartDialog(dialogSets[LevelTrust].Dialogs[dialogNum], Name, head);
    }

    // по завершению диалога проверяем накопленные очки
    private void EndDialogEventReciever(int score)
    {
        if (randomWalking != null) randomWalking.isWorking = true;
        while (score > dialogSets[LevelTrust].CountBallsForNextLevel)
        {
            // если это последний лвл, то брейчим цикл
            if (LevelTrust == dialogSets.Length - 1) break;
            score -= dialogSets[LevelTrust].CountBallsForNextLevel;
            LevelTrust++;
            dialogNum = 0;
        }
        SaveProgress();
    }
}
