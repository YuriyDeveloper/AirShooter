public class GameInitialState : IState
{
    private Services _services;

    private GameStateMachine _gameStateMachine;

    public GameInitialState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
        RegisterServices();
    }
  
    public void Enter()
    {
        _gameStateMachine.Enter<LoadSceneState, string>(ScenePath.downloadScene);
    }

    public void RegisterServices()
    {
        _services = new Services();
        _services.Register(ServicesKey._gameStateMachine, new GameStateMachine());
        _services.Register(ServicesKey._bulletFactory, new BulletFactory());
        _services.Register(ServicesKey._enemyFactory, new EnemyFactory());
        _services.Register(ServicesKey._uiFactory, new UIFactory());
    }

    public void Exit()
    {

    }
  
}
public static class ServicesKey
{
    public const string _gameStateMachine = "gameStateMachine";
    public const string _bulletFactory = "bulletFactory";
    public const string _enemyFactory = "enemyFactory";
    public const string _uiFactory = "uiFactory";

}