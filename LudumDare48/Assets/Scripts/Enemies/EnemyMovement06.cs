using System;
using System.Collections;
using System.Collections.Generic;
using ErksUnityLibrary;
using UnityEngine;

public class EnemyMovement06 : EnemyMovement
{
    private Vector2 dir;

    private void Awake()
    {
        dir = Game.inst.GetPlayerPosition() - transform.position;
        dir = dir.normalized;
    }

    protected override void Move()
    {
        rb2d.velocity = dir * (moveSpeed * 2);
    }
}
