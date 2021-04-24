using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public LevelsList levelsList;
    public int currentLevel = 1;
    public float irrationality = 0f;

    public void AddIrrationality(float value)
    {
        irrationality += value;
    }

    public void OnNewLevelReached()
    {
        currentLevel++;
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
