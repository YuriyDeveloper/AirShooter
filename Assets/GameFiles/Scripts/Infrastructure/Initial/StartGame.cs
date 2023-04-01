using UnityEngine;

public class StartGame
{
    private GameStateMachine _gameStateMachine;

    public StartGame()
    {
        _gameStateMachine = new GameStateMachine();
        _gameStateMachine.Enter<ProjectInitialState>();
    }
}
