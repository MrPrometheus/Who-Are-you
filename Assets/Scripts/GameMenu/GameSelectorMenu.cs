using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSelectorMenu : MonoBehaviour
{
    [Inject] private MySceneController _mySceneController;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject button;

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void OpenMenu()
    {
        menuPanel.SetActive(true);
        button.SetActive(false);
    }

    public void CloseMenu()
    {
        menuPanel.SetActive(false);
        button.SetActive(true);
    }


    public void Exit()
    {
        _mySceneController.LoadMainMenu();
    }
}
