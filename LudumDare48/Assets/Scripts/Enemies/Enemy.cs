using System;
using System.Collections;
using System.Collections.Generic;
using ErksUnityLibrary;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator animator;
    public float moveSpeed;
    public int moveDirection;
    public EnemyType type;

    public void Init(float moveSpeed, int moveDirection)
    {
        this.moveSpeed = moveSpeed;
        this.moveDirection = moveDirection;

        if (moveDirection == -1)
        {
            transform.SetScaleX(-1);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        Move();
        CheckOutOfBounds();
    }

    protected virtual void Move() { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.PlayerTag))
        {
            OnEnterPlayer();
        }
    }

    private void OnEnterPlayer()
    {
        Game.inst.OnEnemyEnterPlayer(this);
        Destroy(gameObject);
    }

    private void CheckOutOfBounds()
    {
        Vector4 bounds = Game.inst.world.GetDisappearBounds();
        bool insideBounds = transform.position.x > bounds.x && transform.position.x < bounds.y &&
                            transform.position.y > bounds.z && transform.position.y < bounds.w;

        if (!insideBounds)
        {
            Destroy(gameObject);
        }
    }
}
