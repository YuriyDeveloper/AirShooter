
using UnityEngine;

public class GameInitialState : IState
{
    private SceneLoader _sceneLoader;
    private GameStateMachine _gameStateMachine;
    public GameInitialState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = new SceneLoader();
    }
  
    public void Enter()
    {
        _gameStateMachine.Enter<LoadSceneState>();
    }

    public void Exit()
    {
    }
}
