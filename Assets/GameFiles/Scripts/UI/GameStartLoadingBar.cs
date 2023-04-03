using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartLoadingBar : MonoBehaviour
{
    [SerializeField] private Slider _loadingBar;

    private void Update()
    {
        _loadingBar.value = SceneLoader.sceneLoadProgress;
        //Debug.Log(SceneLoader.sceneLoadProgress);
    }
}
