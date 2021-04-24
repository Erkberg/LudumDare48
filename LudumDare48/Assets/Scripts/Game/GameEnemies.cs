using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ErksUnityLibrary;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameEnemies : MonoBehaviour
{
    public List<Enemy> enemiesPrefabs;
    public Transform enemiesHolder;

    private float spawnTimePassed = 0f;
    
    private void Update()
    {
        if (DoesCurrentLevelHaveEnemies())
        {
            CountSpawnEnemies();    
        }
    }

    private void CountSpawnEnemies()
    {
        Timing.AddTimeAndCheckMax(ref spawnTimePassed, GetCurrentSpawnTime(), Time.deltaTime, SpawnEnemy);
    }

    private void SpawnEnemy()
    {
        spawnTimePassed = 0f;
        EnemyData enemyData = GetSpawnableEnemyData();
        Enemy enemyPrefab = GetSpawnableEnemyPrefabByData(enemyData);
        
        Vector3 spawnPosition = Vector3.zero;
        int moveDirection = 0;

        switch (enemyData.spawnBehaviour)
        {
            case EnemySpawnBehaviour.OnlyHorizontal:
                spawnPosition = Game.inst.world.GetRandomHorizontalSpawnPosition();
                moveDirection = spawnPosition.x > Game.inst.GetPlayerPosition().x ? -1 : 1;
                break;
            
            case EnemySpawnBehaviour.OnlyBottom:
                spawnPosition = Game.inst.world.GetRandomBottomSpawnPosition();
                break;
        }

        Enemy instantiatedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, enemiesHolder);
        float moveSpeed = Random.Range(enemyData.minSpeed, enemyData.maxSpeed) * GetEnemiesMoveSpeedMultiplier();
        instantiatedEnemy.Init(moveSpeed, moveDirection, GetRandomAvailableQuote());
    }

    private string GetRandomAvailableQuote()
    {
        return Game.inst.progress.availableQuoteDatas.GetRandomItem().text;
    }
    
    private EnemyData GetSpawnableEnemyData()
    {
        List<EnemyData> enemyDatas = Game.inst.progress.GetCurrentLevelData().enemyDatas;
        EnemyData enemyData = enemyDatas[Random.Range(0, enemyDatas.Count)];

        return enemyData;
    }

    private Enemy GetSpawnableEnemyPrefabByData(EnemyData enemyData)
    {
        return enemiesPrefabs.FirstOrDefault(enemyPrefab => enemyPrefab.type == enemyData.type);
    }

    public float GetEnemiesMoveSpeedMultiplier()
    {
        return Mathf.Sqrt(Game.inst.progress.currentLevel);
    }

    private float GetCurrentSpawnTime()
    {
        return Game.inst.progress.GetCurrentLevelData().enemySpawnTime;
    }

    private bool DoesCurrentLevelHaveEnemies()
    {
        return Game.inst.progress.GetCurrentLevelData().enemyDatas.Count > 0;
    }
}
