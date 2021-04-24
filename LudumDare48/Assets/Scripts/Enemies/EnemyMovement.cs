using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float moveSpeed;
    public int moveDirection;
    
    public virtual void OnUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        
    }
}
