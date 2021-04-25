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
    
    public bool inEndSeq = false;

    private GameInput input;

    private bool isDashing = false;
    private Quaternion targetRotation;
    private PlayerAnimation playerAnimation;
    private Vector2 currentLookDir;

    private void Awake()
    {
        input = Game.inst.input;
        playerAnimation = Game.inst.refs.playerController.playerAnimation;
    }

    private void Update()
    {
        if (inEndSeq)
        {
            rb2d.AddForce(Vector2.up * (moveSpeed * 1.5f));
            SetTargetRotation(Vector2.up);
            Rotate();
            playerAnimation.SetMoving(true);
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        Vector2 movement = new Vector2(input.GetHorizontalMovement(), input.GetVerticalMovement());
        Vector2 mouseDir = input.GetMouseWorldPosition() - (Vector2) transform.position;

        // support for mouse movement
        if (input.GetLeftMouseButton())
        {
            movement = mouseDir;
        }
        
        movement = CapY(movement).normalized;

        // accelerate only when not at max speed or currently dashing
        if (rb2d.velocity.sqrMagnitude < maxMoveSpeed && !isDashing)
        {
            rb2d.AddForce(movement * moveSpeed);
        }
        
        if (movement.sqrMagnitude > 0.1f)
        {
            SetTargetRotation(movement);
            currentLookDir = movement;
        }
        
        Rotate();
        
        CheckDash(currentLookDir);
        
        playerAnimation.SetMoving(movement != Vector2.zero);
    }

    private Vector2 CapY(Vector2 movement)
    {
        if (transform.position.y > Game.inst.world.GetHighestY() && movement.y >= 0f)
        {
            movement.y = Physics2D.gravity.y;
        }
        
        if (transform.position.y < Game.inst.world.GetLowestY() && movement.y <= 0f)
        {
            movement.y = -Physics2D.gravity.y;
        }

        return movement;
    }

    private void CheckDash(Vector2 movement)
    {
        if (!isDashing && input.GetDashButton())
        {
            playerAnimation.TriggerDash();
            Game.inst.audio.PlayDashSound();
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

    private void SetTargetRotation(Vector2 movement)
    {
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    private void Rotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.5f);
    }

    public void SetRigidbodySimulated(bool simulated)
    {
        rb2d.simulated = simulated;
    }
}
