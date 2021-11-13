using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardInput : MonoBehaviour
{
    public event UnityAction<Vector2> Moooved;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            Moooved?.Invoke(Vector2.up);

        if (Input.GetKey(KeyCode.S))
            Moooved?.Invoke(Vector2.down);

        if (Input.GetKey(KeyCode.A))
            Moooved?.Invoke(Vector2.left);

        if (Input.GetKey(KeyCode.D))
            Moooved?.Invoke(Vector2.right);
    }
}
