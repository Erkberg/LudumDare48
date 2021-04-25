using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game inst;

    public GameState currentState = GameState.StartScreen;
    
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
        refs.playerController.playerMovement.SetRigidbodySimulated(false);
    }

    private void Update()
    {
        CheckPauseMenu();
    }

    private void CheckPauseMenu()
    {
        if (input.GetQuitButtonDown())
        {
            switch (currentState)
            {
                case GameState.Ingame:
                    ui.pauseMenuOverlay.SetActive(true);
                    currentState = GameState.PauseMenu;
                    Time.timeScale = 0f;
                    break;
                
                case GameState.PauseMenu:
                    ContinueGame();
                    break;
            }
        }
    }

    public void StartGame()
    {
        ui.titleScreenOverlay.SetActive(false);
        input.SetInputEnabled(true);
        refs.playerController.playerMovement.SetRigidbodySimulated(true);
        currentState = GameState.Ingame;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ContinueGame()
    {
        ui.pauseMenuOverlay.SetActive(false);
        currentState = GameState.Ingame;
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnGameEndReached()
    {
        ui.endingMenuOverlay.SetActive(true);
        currentState = GameState.EndScreen;
        Time.timeScale = 0f;
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

    public enum GameState
    {
        Ingame,
        StartScreen,
        PauseMenu,
        EndScreen
    }
}
