using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : IState
{
    private GameStateMachine _gameStateMachne;

    public MainMenuState(GameStateMachine gameStateMachine)
    {
        _gameStateMachne = gameStateMachine;
    }

    public void Enter()
    {

    }

    public void Exit()
    {

    }
}
