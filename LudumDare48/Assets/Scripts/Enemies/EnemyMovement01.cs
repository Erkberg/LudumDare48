using System.Collections;
using System.Collections.Generic;
using ErksUnityLibrary;
using UnityEngine;

public class EnemyMovement01 : EnemyMovement
{
    protected override void Move()
    {
        rb2d.SetVelocityX(moveSpeed * moveDirection);
    }
}
