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

    public PlayerController player;
    public Camera mainCam;

    private void Awake()
    {
        inst = this;
    }

    public void OnEnemyEnterPlayer(Enemy enemy)
    {
        progress.AddIrrationality(0.1f);
        ui.irrationalityMeter.UpdateFill();
    }
}
