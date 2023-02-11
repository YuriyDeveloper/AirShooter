
public class LoadSceneState : IState
{
    private GameStateMachine _gameStateMachine;
    private SceneLoader _sceneLoader;
    private readonly string _sceneName;
    public LoadSceneState(GameStateMachine gameStateMachine)
    {
        _sceneLoader = new SceneLoader();
        _gameStateMachine = gameStateMachine;
    }
    public void Enter()
    {
        _sceneLoader.Load(ScenePath.downloadScene);
    }

    public void Exit()
    {
        
    }
}
