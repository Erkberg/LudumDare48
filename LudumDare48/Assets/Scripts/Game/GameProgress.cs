using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public LevelsList levelsList;
    public int currentLevel = 0;
    public float irrationality = 0f;

    public void AddIrrationality(float value)
    {
        irrationality += value;

        if (irrationality > 1f)
            irrationality = 1f;
    }

    public void OnLevelBarrierReached(int levelId)
    {
        currentLevel = levelId;
    }
    
    public void ResetProgress()
    {
        irrationality = 0f;
        currentLevel = 1;
    }
    
    public LevelData GetCurrentLevelData()
    {
        return levelsList.levels[currentLevel];
    }
}
