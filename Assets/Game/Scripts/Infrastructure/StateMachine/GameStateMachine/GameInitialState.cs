using UnityEngine;

public class GameInitialState : IState
{
    private Services _services;

    private IGameStateMachine _gameStateMachine;

    public GameInitialState(IGameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
        RegisterServices();
    }
  
    public void Enter()
    {
        _gameStateMachine.Enter<LoadSceneState, string>(ScenePath.mainMenuScene);
    }

    public void RegisterServices()
    {
        Debug.Log("3");
        _services = new Services();
        _services.RegisterSingle(_gameStateMachine);
        _services.RegisterSingle(new BulletFactory());
        _services.RegisterSingle(new EnemyFactory());
        _services.RegisterSingle(new UIFactory());
    }

    public void Exit()
    {

    }
  
}