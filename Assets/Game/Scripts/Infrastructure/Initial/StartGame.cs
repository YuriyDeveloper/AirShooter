using UnityEngine;

public class StartGame
{
    private GameStateMachine _gameStateMachine;

    public StartGame()
    {
        Debug.Log("1");
        _gameStateMachine = new GameStateMachine();
        _gameStateMachine.Enter<GameInitialState>();
    }
}
