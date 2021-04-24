using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float moveSpeed = 1f;
    public float maxMoveSpeed = 10f;
    public float dashSpeed = 100f;
    public float dashDuration = 0.5f;

    private GameInput input;

    private bool isDashing = false;

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

        // support for mouse movement
        if (input.GetLeftMouseButton())
        {
            movement = input.GetMouseWorldPosition() - (Vector2)transform.position;
        }
        
        movement = movement.normalized;

        // accelerate only when not at max speed or currently dashing
        if (rb2d.velocity.sqrMagnitude < maxMoveSpeed || isDashing)
        {
            rb2d.AddForce(movement * moveSpeed);
        }
        
        CheckDash(movement);

        if (movement.sqrMagnitude > 0f)
        {
            Rotate(movement);
        }
    }

    private void CheckDash(Vector2 movement)
    {
        if (!isDashing && input.GetDashButtonDown())
        {
            isDashing = true;
            rb2d.AddForce(movement * dashSpeed, ForceMode2D.Impulse);
            StartCoroutine(DashSequence());
        }
    }

    private IEnumerator DashSequence()
    {
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }
    
    private void Rotate(Vector2 movement)
    {
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
