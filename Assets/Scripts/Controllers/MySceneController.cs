using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneController
{
    public void LoadFirstScene()
    {
        ReloadDoor.isTeleportToPoint = true;
        SceneManager.LoadSceneAsync("bashnya");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
