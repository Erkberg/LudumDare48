using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRenderer : MonoBehaviour
{
    private void Start()
    {
        Game.inst.ui.enemyCompass.AddEnemy(transform);
    }

    private void OnBecameVisible()
    {
        Game.inst.ui.enemyCompass.RemoveEnemy(transform);
    }

    private void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy)
        {
            Game.inst.ui.enemyCompass.AddEnemy(transform);
        }
    }

    private void OnDestroy()
    {
        Game.inst.ui.enemyCompass.RemoveEnemy(transform);
    }
}
