using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorAnimController : MonoBehaviour
{
    private Animator doctorAnim;
    private Move move = null;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    public Vector2 Direction { get { return move.Direction; } }

    void Start()
    {
        doctorAnim = GetComponent<Animator>();
        move = GetComponent<Move>();
    }

    void Update()
    {
        //Debug.Log(move.Dirction);
        if (Direction.magnitude > 0) doctorAnim.SetBool(IsRunning, true);
        else doctorAnim.SetBool(IsRunning, false);
    }
}
