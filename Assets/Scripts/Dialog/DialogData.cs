using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "DialogData", menuName = "Dialog/DialogData")]
public class DialogData : ScriptableObject
{
    public PersonDialog[] PersonDialogs;

    public DialogSet[] GetDialogSet(Employee employee)
    {
        foreach (PersonDialog PersonDialog in PersonDialogs)
            if (PersonDialog.MyEmployee == employee) return PersonDialog.DialogSets;
        return null;
    }
}
