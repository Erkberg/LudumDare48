using System.Collections;
using System.Collections.Generic;
using ErksUnityLibrary;
using UnityEngine;

public class GameWorld : MonoBehaviour
{
    public Transform background;
    public List<Transform> forebackgrounds;
    public Transform levelBarrierPrefab;
    public GameEnding ending;

    private const float SpawnOffsetX = 12f;
    private const float SpawnOffsetY = 8f;

    public void Init()
    {
        AdjustBackgroundSizeAndPosition();
        SpawnLevelBarriers();
    }

    private void AdjustBackgroundSizeAndPosition()
    {
        float totalDepth = GetTotalDepth();
        
        background.SetScaleY(totalDepth);
        background.SetPositionY(totalDepth * -0.64f);

        totalDepth += 8;
        foreach (Transform forebackgrounds in forebackgrounds)
        {
            forebackgrounds.SetScaleY(totalDepth / 2);
            forebackgrounds.SetPositionY(totalDepth * -0.64f);
        }
    }

    private void SpawnLevelBarriers()
    {
        float addedDepth = 0f;
        
        foreach (LevelData levelData in Game.inst.progress.levelsList.levels)
        {
            Transform levelBarrier = Instantiate(levelBarrierPrefab, background);
            addedDepth += levelData.depth;
            levelBarrier.localScale = new Vector3(1f / background.localScale.x, 1f / background.localScale.y, 1f);
            levelBarrier.position = new Vector3(background.position.x, -addedDepth * 1.28f, 0f);
            levelBarrier.GetComponent<LevelBarrier>().levelId = levelData.id;
        }
        
        ending.transform.position = new Vector3(background.position.x, -addedDepth * 1.28f, 0f);
    }

    public float GetHighestY()
    {
        return 0f;
    }

    public float GetLowestY()
    {
        return -GetTotalDepth() * 1.28f;
    }

    public float GetTotalDepth()
    {
        float totalDepth = 0f;
        
        foreach (LevelData levelData in Game.inst.progress.levelsList.levels)
        {
            totalDepth += levelData.depth;
        }

        return totalDepth;
    }
    
    public Vector3 GetRandomHorizontalSpawnPosition()
    {
        Vector3 playerPosition = Game.inst.GetPlayerPosition();
        int direction = Random.Range(0f, 1f) < 0.5f ? -1 : 1;
        float posX = playerPosition.x + direction * SpawnOffsetX;
        float posY = playerPosition.y + Random.Range(-SpawnOffsetY * 2, 0f);
        return new Vector3(posX, posY, 0f);
    }
    
    public Vector3 GetRandomVerticalSpawnPosition()
    {
        Vector3 playerPosition = Game.inst.GetPlayerPosition();
        int direction = Random.Range(0f, 1f) < 0.75f ? -1 : 1;
        float posX = playerPosition.x + Random.Range(-SpawnOffsetX * 0.75f, SpawnOffsetX * 0.75f);
        float posY = playerPosition.y + direction * SpawnOffsetY;
        return new Vector3(posX, posY, 0f);
    }

    public Vector3 GetRandomSpawnPosition()
    {
        return Random.Range(0f, 1f) < 0.5f ? GetRandomHorizontalSpawnPosition() : GetRandomVerticalSpawnPosition();
    }

    public Vector4 GetDisappearBounds()
    {
        float disappearBoundsMultiplier = 2f;
        Vector3 playerPosition = Game.inst.GetPlayerPosition();
        float boundsLeft = playerPosition.x - SpawnOffsetX * disappearBoundsMultiplier;
        float boundsRight = playerPosition.x + SpawnOffsetX * disappearBoundsMultiplier;
        float boundsBottom = playerPosition.y - SpawnOffsetY * disappearBoundsMultiplier;
        float boundsTop = playerPosition.y + SpawnOffsetY * disappearBoundsMultiplier;
        return new Vector4(boundsLeft, boundsRight, boundsBottom, boundsTop);
    }
}
