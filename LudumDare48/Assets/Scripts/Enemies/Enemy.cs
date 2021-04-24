using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator animator;
    public float moveSpeed;
    public int moveDirection;
    public EnemyType type;

    public void Init(float minSpeed, float maxSpeed, int moveDirection)
    {
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        this.moveDirection = moveDirection;
    }
    
    // Update is called once per frame
    void Update()
    {
        Move();
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
}
