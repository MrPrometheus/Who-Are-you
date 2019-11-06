using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Employee { Seller, KithenGerl, Granny, Example }

[CreateAssetMenu(fileName = "PersonDialog", menuName = "Dialog/PersonDialog")]
public class PersonDialog : ScriptableObject
{
    public Employee MyEmployee;
    public DialogSet[] DialogSets;
}
