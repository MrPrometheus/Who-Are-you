using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Move : MonoBehaviour
{
    public float Speed = 2f;
    [Inject] public JoysticController _joysticController;
    private Vector2 Direction { get { return _joysticController.currentJoystick.Direction; } }


    void Update()
    { 
        TurnAround(Direction);
        transform.Translate(Speed * Time.deltaTime * Direction);
    }

    private void TurnAround(Vector2 dir)
    {
        if (dir.x > 0) transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        else if (dir.x < 0) transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }
}
