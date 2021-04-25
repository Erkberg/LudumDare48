using System;
using System.Collections;
using System.Collections.Generic;
using ErksUnityLibrary;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public EnemyMovement enemyMovement;
    public Rigidbody2D rb2d;
    public Transform modelHolder;
    public Animator animator;
    public Speechbubble speechbubble;
    public EnemyType type;

    public void Init(float moveSpeed, int moveDirection, string text)
    {
        enemyMovement.moveSpeed = moveSpeed;
        enemyMovement.moveDirection = moveDirection;

        /*if (moveDirection == -1)
        {
            transform.SetScaleX(-1);
            speechbubble.Flip();
        }*/
        
        speechbubble.SetText(text);
        speechbubble.SetActive(true);
    }
    
    // Update is called once per frame
    void Update()
    {
        enemyMovement.OnUpdate();
        CheckOutOfBounds();
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        modelHolder.transform.up = rb2d.velocity.normalized;
    }

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
