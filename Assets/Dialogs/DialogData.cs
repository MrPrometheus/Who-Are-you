using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DialogData : MonoBehaviour
{
    public static DialogData instance = null; // Экземпляр объекта
    public PersonDialog[] PersonDialogs;

    public DialogSet[] GetDialogSet(Employee employee)
    {
        foreach (PersonDialog PersonDialog in PersonDialogs)
            if (PersonDialog.MyEmployee == employee) return PersonDialog.DialogSets;
        return null;
    }


    // Метод, выполняемый при старте игры
    void Awake()
    {
        // Теперь, проверяем существование экземпляра
        if (instance == null)
        { // Экземпляр менеджера был найден
            instance = this; // Задаем ссылку на экземпляр объекта
        }
        else if (instance == this)
        { // Экземпляр объекта уже существует на сцене
            Destroy(gameObject); // Удаляем объект
        }

        // Теперь нам нужно указать, чтобы объект не уничтожался
        // при переходе на другую сцену игры
        DontDestroyOnLoad(gameObject);
    }
}
