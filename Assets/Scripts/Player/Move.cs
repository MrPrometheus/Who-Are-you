using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed = 2f;
    public JoysticController JoysticController;
    public Joystick joystick { get; private set; }
    public Vector2 Direction { get; private set; }

    private void Start()
    {
        joystick = JoysticController.currentJoystick;
    }

    void Update()
    {
        Vector2 direction = Vector2.up * joystick.Vertical + Vector2.right * joystick.Horizontal;
        Direction = direction;
        TurnAround(direction);
        transform.Translate(Speed * Time.deltaTime * direction);
    }

    private void TurnAround(Vector2 dir)
    {
        if (dir.x > 0) transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        else if (dir.x < 0) transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }
}
