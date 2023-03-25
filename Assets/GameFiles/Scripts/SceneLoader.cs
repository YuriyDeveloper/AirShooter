using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private static float _sceneLoadProgress;
    public static float sceneLoadProgress { get => _sceneLoadProgress; }

   
    public void Load(string name)
    {
        
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(name);
        _sceneLoadProgress = loadAsync.progress;
        //SceneManager.LoadScene(name);
    }

  
}
