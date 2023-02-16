using UnityEngine;

public class StartGameLevel : MonoBehaviour
{
    private IGameStateMachine _gameStateMachine;
    public void StartLevel()
    {
        _gameStateMachine = Services.Container.Single<IGameStateMachine>();
        _gameStateMachine.Enter<LoadSceneState, string>(ScenePath.GameLevelScene1);
    }
}
