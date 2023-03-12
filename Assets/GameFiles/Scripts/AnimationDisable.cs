
using UnityEngine;

public class AnimationDisable : MonoBehaviour
{

    private void OnAnimationFinished()
    {
        gameObject.SetActive(false);
    }
}
