using UnityEngine;

public class ProjectInitialState : IState
{
    private Services _services;

    private IGameStateMachine _gameStateMachine;

    public ProjectInitialState(IGameStateMachine gameStateMachine)
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
        _services = new Services();
       
        _services.RegisterSingle(_gameStateMachine);
        _services.RegisterSingle<IGameData>(new GameData());
        _services.RegisterSingle<IBulletFactory>(new BulletFactory());
        _services.RegisterSingle<IEnemyFactory>(new EnemyFactory());
        _services.RegisterSingle<IUIFactory>(new UIFactory());
        _services.RegisterSingle<IGiftFactory>(new GiftFactory());
        _services.RegisterSingle<IAssetProvider>(new AssetProvider());
        Debug.Log("Services are registered");
    }

    public void Exit()
    {

    }
  
}