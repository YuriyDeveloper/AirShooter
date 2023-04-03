using System;
using System.Collections;
using UnityEngine;

public class GameLoopState : IState
{
    private GameStateMachine _gameStateMachine;

    public static Action OnStartSingleEnemySpawner;
    public static Action OnStartGroupEnemySpawner;
    //public static Action 

    public GameLoopState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
       //Invoke("")
       Debug.Log("Enter to GameLoopState!");
    }

    public void Exit()
    {
        
    }

    private void StartEnemySpawn()
    {
        OnStartGroupEnemySpawner?.Invoke();
        OnStartGroupEnemySpawner?.Invoke();
        Debug.Log("Start spawn!");
    }
}
