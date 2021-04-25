using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public LevelsList levelsList;
    
    public int currentLevel = 0;
    public float irrationality = 0f;
    public List<QuoteData> availableQuoteDatas = new List<QuoteData>();

    public void AddIrrationality(float value)
    {
        irrationality += value;

        if (irrationality > 1f)
            irrationality = 1f;
    }

    public void OnLevelBarrierReached(int levelId)
    {
        Debug.Log($"switch level to {levelId}");
        currentLevel = levelId;
        AddNewQuotes();
        CheckEnding();
    }

    private void CheckEnding()
    {
        if (currentLevel == levelsList.levels.Count - 1)
        {
            Game.inst.OnGameEndReached();
        }
    }

    private void AddNewQuotes()
    {
        foreach (QuoteData newQuote in levelsList.levels[currentLevel].newQuotes)
        {
            if (!availableQuoteDatas.Contains(newQuote))
            {
                availableQuoteDatas.Add(newQuote);
            }
        }
    }
    
    public void ResetProgress()
    {
        irrationality = 0f;
        currentLevel = 1;
        availableQuoteDatas.Clear();
    }
    
    public LevelData GetCurrentLevelData()
    {
        return levelsList.levels[currentLevel];
    }
}
