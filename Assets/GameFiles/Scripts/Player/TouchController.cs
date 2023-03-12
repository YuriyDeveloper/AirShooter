
using UnityEngine;

public class TouchController : MonoBehaviour
{
    private Vector3 _touchPosition;
    private Rigidbody2D _rigidbody;
    private Vector3 _direction;
    private float _moveSpeed = 10f;

    private void Start()
    {

        _rigidbody = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        Control();
    }

    private void Control()
    {
         if (Input.touchCount > 0)
         {
             Touch touch = Input.GetTouch(0);
             _touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
             _touchPosition.z = 0;
             _direction = (_touchPosition - transform.position);
             _rigidbody.velocity = new Vector2(_direction.x, _direction.y) * _moveSpeed;

             if (touch.phase == TouchPhase.Ended)
             {
                 _rigidbody.velocity = Vector2.zero;
             }
         }
    }


}
