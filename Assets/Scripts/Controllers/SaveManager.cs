using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SaveManager
{
    public string FileName = "player_data";
    public DataToSave dataToSave;

    [Inject] private JSONSaver _JSONSaver;
    private bool started = false;
    
    
    public async void InitialData()
    {
        // инициировать могут сразу несколько сущностей, 
        // но иницировать можно только один раз 
        if (!started)
        {
            started = true;
            if (SceneManager.GetActiveScene().name != "MainMenu" && dataToSave == null)
            {
                // ждем, пока загрузится _JSONSaver
                while (_JSONSaver == null) await Task.Yield();
                // если есть сохранения
                // (очень поможет при тестировании, если запускать не с со сцены меню)
                if (isSaveDataExists())
                    // загрузи их
                    Load();
                else Discharge();
            }
        }
    }

    public bool isSaveDataExists()
    {
        return _JSONSaver.FileExists(FileName);
    }
    /// <summary>
    /// Сохранить ститистику
    /// </summary>
    public void SaveStatic()
    {
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