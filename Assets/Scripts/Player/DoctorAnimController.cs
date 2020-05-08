using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DoctorAnimController : MonoBehaviour
{
    private Animator doctorAnim;
    [Inject]
    private JoysticController _joysticController;
    public Vector2 Direction { get { return _joysticController.currentJoystick.Direction; } }
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    void Start()
    {
        doctorAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Direction.magnitude > 0) doctorAnim.SetBool(IsRunning, true);
        else doctorAnim.SetBool(IsRunning, false);
    }
}
