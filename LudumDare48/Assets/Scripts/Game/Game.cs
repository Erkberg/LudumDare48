using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game inst;

    public GameUI ui;
    public GameProgress progress;
    public GameInput input;
    public GameEnemies enemies;
    public GameWorld world;
    public GameRefs refs;
    public GameAudio audio;

    private void Awake()
    {
        inst = this;
        
        world.Init();
    }

    public void OnEnemyEnterPlayer(Enemy enemy)
    {
        progress.AddIrrationality(0.1f);
        ui.irrationalityMeter.UpdateFill();
    }

    public Vector3 GetPlayerPosition()
    {
        return refs.playerController.playerMovement.transform.position;
    }

    private void OnDestroy()
    {
        inst = null;
    }
}
