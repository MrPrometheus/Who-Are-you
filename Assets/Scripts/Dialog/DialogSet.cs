using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "DialogSet", menuName = "Dialog/DialogSet")]
public class DialogSet : ScriptableObject
{
    public int CountBallsForNextLevel = 0;
    public Dialog[] Dialogs;
}
