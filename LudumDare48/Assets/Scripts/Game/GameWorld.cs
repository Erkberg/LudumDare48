using System.Collections;
using System.Collections.Generic;
using ErksUnityLibrary;
using UnityEngine;

public class GameWorld : MonoBehaviour
{
    public LevelsList levelsList;
    public Transform background;
    public Transform newLevelPrefab;

    private const float SpawnOffsetX = 12f;
    private const float SpawnOffsetY = 8f;

    public void Init()
    {
        AdjustBackgroundSizeAndPosition();
        SpawnNewLevelObjects();
    }

    private void AdjustBackgroundSizeAndPosition()
    {
        float totalDepth = GetTotalDepth();
        
        background.SetScaleY(totalDepth);
        background.SetPositionY(totalDepth * -0.64f);
    }

    private void SpawnNewLevelObjects()
    {
        
    }

    public float GetHighestY()
    {
        return 0f;
    }

    public float GetLowestY()
    {
        return -GetTotalDepth();
    }

    public float GetTotalDepth()
    {
        float totalDepth = 0f;
        
        foreach (LevelData levelData in levelsList.levels)
        {
            totalDepth += levelData.depth;
        }

        return totalDepth;
    }
    
    public Vector3 GetRandomHorizontalSpawnPosition()
    {
        Vector3 playerPosition = Game.inst.refs.playerController.playerMovement.transform.position;
        int direction = Random.Range(0f, 1f) < 0.5f ? -1 : 1;
        float posX = playerPosition.x + direction * SpawnOffsetX;
        float posY = playerPosition.y + Random.Range(0f, SpawnOffsetY);
        return new Vector3(posX, posY, 0f);
    }
    
    public Vector3 GetRandomBottomSpawnPosition()
    {
        Vector3 playerPosition = Game.inst.refs.playerController.playerMovement.transform.position;
        float posX = playerPosition.x + Random.Range(-SpawnOffsetX, SpawnOffsetX);
        float posY = playerPosition.y + SpawnOffsetY;
        return new Vector3(posX, posY, 0f);
    }
}
