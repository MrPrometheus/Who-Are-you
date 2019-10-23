using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// дверь, котрая при перемещении телепортирует в точку
/// </summary>
public class ReloadDoor : Door
{
    /// <summary>
    /// Дополнительная точка, в которую будем телепортироваться если isTeleportToPoint == true
    /// </summary>
    public Transform AdditionPoint;
    /// <summary>
    /// Указатель того, что нужно телепортироваться в дополнительную, а не в основную точку
    /// </summary>
    public static bool isTeleportToPoint;

    protected override void Start()
    {
        
        if (isTeleportToPoint) // если надо телепортироваться в дополнительную точку
        {
            if (SceneManager.GetActiveScene().name == "OpenWorld") isTeleportToPoint = false;
            ChangePositionEvent(AdditionPoint.position);
        }
        else base.Start();
    }
}
