using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SelectorMenu : MonoBehaviour
{
    public GameObject[] menuSet;
    [Inject] private SaveManager _saveManager;
    [Inject] private MessageBox _messageBox;
    [Inject] private MySceneController _mySceneController;

    public void ShowMenu(int num)
    {
        foreach (GameObject i in menuSet)
            i.SetActive(false);
        menuSet[num].SetActive(true);
    }

    public void ContinueGame()
    {
        try
        {
            _saveManager.Load();
        }
        catch (System.IO.FileNotFoundException)
        {
            _messageBox.Message("Не найдено последнее сохранение.");
            return;
        }
        _mySceneController.LoadFirstScene();
    }

}
