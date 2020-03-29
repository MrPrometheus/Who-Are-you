using UnityEngine;
using Zenject;

public class SelectorMenu : MonoBehaviour
{
    public GameObject[] menuSet;
    [Inject] private SaveManager _saveManager;
    [Inject] private MessageBox _messageBox;
    [Inject] private MySceneController _mySceneController;
    [Inject] private VideoControiler _videoControiler;

    public void ShowMenu(int num)
    {
        foreach (GameObject i in menuSet)
            i.SetActive(false);
        menuSet[num].SetActive(true);
    }

    public async void NewGame()
    {
        string message = "Осторожно, это может сбросить предыдущий игровой процесс.";
        string yes = "Продолжить";
        string no = "Отмена";
        // если есть предыдущие сохранения
        if (_saveManager.isSaveDataExists())
            // если игрок не согласен их удалить - прерываем
            if (!await _messageBox.Question(message, yes, no))
                return;
        // иначе сбрасываем все сохранения и начинаем новую игру
        _saveManager.Discharge();
        _videoControiler.NewGameStart();
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
