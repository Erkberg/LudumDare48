using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnemies : MonoBehaviour
{
    public float GetEnemiesMoveSpeedMultiplier()
    {
        return Mathf.Sqrt(Game.inst.progress.currentLevel);
    }
}
