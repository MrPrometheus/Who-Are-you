using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorMenu : MonoBehaviour
{
    public GameObject[] menuSet;

    public void ShowMenu(int num)
    {
        foreach (GameObject i in menuSet)
            i.SetActive(false);
        menuSet[num].SetActive(true);
    }
}
