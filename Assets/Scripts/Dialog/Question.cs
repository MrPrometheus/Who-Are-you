using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Dialog/Question")]
public class Question : ScriptableObject
{
    public string NPCQuestion; 
    public string[] Answers;
    public int[] PointsForQuestion;
    public int[] NextQuestionNumber;
}
