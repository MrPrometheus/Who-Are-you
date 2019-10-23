using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System;

[Serializable]
public class Question
{
    [DataMember]
    public string question;
    [DataMember]
    public string[] answers;
    [DataMember]
    public int[] pointsForQuestion;
    public int[] qustionNumber;
}
