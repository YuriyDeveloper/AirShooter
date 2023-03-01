
using UnityEngine;

public class TouchController : MonoBehaviour
{
    private Touch _touch;
    private float _speedModifier;

    private void Start()
    {
        _speedModifier = 0.01f;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + _touch.deltaPosition.x * _speedModifier,
                    transform.position.y,
                    transform.position.z + _touch.deltaPosition.y * _speedModifier
                    );
                
                   
                
            }
        }
    }
}
