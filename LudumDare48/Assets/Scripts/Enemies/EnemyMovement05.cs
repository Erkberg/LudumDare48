using System.Collections;
using System.Collections.Generic;
using ErksUnityLibrary;
using UnityEngine;

public class EnemyMovement05 : EnemyMovement
{
    public float wiggleAmount = 2f;
    public float wiggleDeviation = 1f;

    private float startTime;
    private float timeMultiplier;

    private void Awake()
    {
        wiggleAmount += Random.Range(-wiggleDeviation, wiggleDeviation);
        timeMultiplier = Random.Range(-0.5f, 2f);
        startTime = Time.time;
    }

    protected override void Move()
    {
        rb2d.SetVelocityY(moveSpeed * moveDirection);

        float veloX = Mathf.Sin((Time.time - startTime) * timeMultiplier) * moveSpeed * wiggleAmount;
        rb2d.SetVelocityX(veloX);
    }
}
