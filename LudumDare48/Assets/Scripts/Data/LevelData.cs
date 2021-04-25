using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public int id;
    public float depth;
    public float enemySpawnTime;
    public float overrideSpeedMultiplier;
    public int musicId;
    public List<EnemyData> enemyDatas;
    public List<QuoteData> newQuotes;
}
