using System.Collections;
using System.Collections.Generic;
using ErksUnityLibrary;
using UnityEngine;

public class Enemy01 : Enemy
{
    protected override void Move()
    {
        rb2d.SetVelocityX(moveSpeed * moveDirection);
    }
}
