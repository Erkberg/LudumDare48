using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBarrier : MonoBehaviour
{
    public int levelId;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.PlayerTag))
        {
            Game.inst.progress.OnLevelBarrierReached(levelId);
        }
    }
}
