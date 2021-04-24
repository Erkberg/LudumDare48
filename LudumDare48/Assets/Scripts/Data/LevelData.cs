using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public int id;
    public float length;
    public float enemySpawnTime;
    public List<EnemyData> enemyDatas;
    public List<QuoteData> newQuotes;
}
