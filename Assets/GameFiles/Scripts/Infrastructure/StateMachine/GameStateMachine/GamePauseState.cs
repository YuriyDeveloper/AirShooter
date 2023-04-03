using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseState : IState
{
    private GameStateMachine _gameStateMachine;

    public GamePauseState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }
}
