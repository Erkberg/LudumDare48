using System;
using System.Collections;
using System.Collections.Generic;
using ErksUnityLibrary;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement03 : EnemyMovement
{
    public float chaseDuration = 10f;
    public float chaseDurationDeviation = 3f;
    
    private float chaseDurationPassed = 0f;

    private void Awake()
    {
        chaseDuration += Random.Range(-chaseDurationDeviation, chaseDurationDeviation);
    }

    public override void OnUpdate()
    {
        chaseDurationPassed += Time.deltaTime;
        
        base.OnUpdate();
    }

    protected override void Move()
    {
        Vector3 moveDir = Game.inst.GetPlayerPosition() - transform.position;
        if (ChaseEnded())
        {
            rb2d.velocity = -moveSpeed * moveDir.normalized;
        }
        else
        {
            rb2d.velocity = moveSpeed * moveDir.normalized;
        }
    }

    private bool ChaseEnded()
    {
        return chaseDurationPassed > chaseDuration;
    }
}
