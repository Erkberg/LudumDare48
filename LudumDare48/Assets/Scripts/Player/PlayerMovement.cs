using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float moveSpeed = 1f;
    public float maxMoveSpeed = 10f;

    private GameInput input;

    private void Awake()
    {
        input = Game.inst.input;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = new Vector2(input.GetHorizontalMovement(), input.GetVerticalMovement());

        if (rb2d.velocity.sqrMagnitude < maxMoveSpeed)
        {
            rb2d.AddForce(movement * moveSpeed);
        }

        if (movement.sqrMagnitude > 0f)
        {
            Rotate(movement);
        }
    }
    
    private void Rotate(Vector2 movement)
    {
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
