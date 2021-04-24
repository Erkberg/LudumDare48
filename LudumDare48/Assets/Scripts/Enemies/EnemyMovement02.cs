using System.Collections;
using System.Collections.Generic;
using ErksUnityLibrary;
using UnityEngine;

public class EnemyMovement02 : EnemyMovement
{
    protected override void Move()
    {
        rb2d.SetVelocityY(moveSpeed * moveDirection);
    }
}
