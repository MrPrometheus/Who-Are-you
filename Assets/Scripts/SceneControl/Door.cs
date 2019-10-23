using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public delegate void DVector(Vector2 vector);

public class Door : MonoBehaviour
{
    /// <summary>
    /// Сцена, куда хотим тпшнуться
    /// </summary>
    public string SceneName = "";
    /// <summary>
    /// Точка, на которой заспавнимся при возвращении на основную сцену, ставиться только на основной сцене
    /// </summary>
    public Transform spawnPosition;
    /// <summary>
    /// Хранилка для точки в виде статической переменной для сохранения координат между сценами
    /// </summary>
    public static Vector2 positionToSpawn;
    /// <summary>
    /// Событие - телепорт в точку
    /// </summary>
    public static event DVector ChangePosition;

    protected virtual void Start()
    {
        if (SceneManager.GetActiveScene().name == "OpenWorld")
        {
            // если у нас есть точка, где мы должны оказатсья и приемник события (PlayerController)
            // нужно для того, чтобы оказаться у двери после выхода из какого нибудь дома
            if (positionToSpawn != Vector2.zero && ChangePosition != null)
            {
                ChangePosition(positionToSpawn);
                positionToSpawn = Vector2.zero;
            }
        }
    }
    
    /// <summary>
    /// метод, для того чтобы дергать это событие из наследников (ReloadDoors)
    /// </summary>
    /// <param name="arg">точка, куда нужно тпшнуться</param>
    protected void ChangePositionEvent(Vector2 arg)
    {
        if (ChangePosition != null) ChangePosition(arg);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            // запоминаем в статическую переменную точку для спавна
            if (spawnPosition != null)
                positionToSpawn = spawnPosition.position;
            SceneManager.LoadScene(SceneName);
        }
    }
}
