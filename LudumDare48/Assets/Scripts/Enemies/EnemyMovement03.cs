using System.Collections;
using System.Collections.Generic;
using ErksUnityLibrary;
using UnityEngine;

public class EnemyMovement03 : EnemyMovement
{
    protected override void Move()
    {
        Vector3 moveDir = Game.inst.GetPlayerPosition() - transform.position;
        rb2d.velocity = moveSpeed * moveDir;
    }
}
