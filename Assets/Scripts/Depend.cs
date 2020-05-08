using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depend : MonoBehaviour
{
    public Transform dependObject;
    public bool x, y, z;

    private void Start()
    {
        dependObject = PlayerController.currntActive.transform;
        DayController.DayHasCome += ChangeDependObj;
        DayController.NightHasCome += ChangeDependObj;
    }

    private void ChangeDependObj()
    {
        dependObject = PlayerController.currntActive.transform;
    }
    

    private void Update()
    {
        Vector3 new_pos = dependObject.transform.position;
        if (!z) new_pos.z = transform.position.z;
        if (!x) new_pos.x = transform.position.x;
        if (!y) new_pos.y = transform.position.y;
        transform.position = new_pos;
    }
}
