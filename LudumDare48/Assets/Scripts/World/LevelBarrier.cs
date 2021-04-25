using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBarrier : MonoBehaviour
{
    public int levelId;

    private bool isActive = true;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive && other.CompareTag(Tags.PlayerTag))
        {
            isActive = false;
            Game.inst.progress.OnLevelBarrierReached(levelId);
        }
    }
}
