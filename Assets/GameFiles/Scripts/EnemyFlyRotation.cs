using UnityEngine;

public class EnemyFlyRotation : MonoBehaviour
{
    [SerializeField] private bool _toRotation;

    private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Rotation();
    }

    private void Rotation()
    {
        if (_rigidbody2D && _toRotation)
        {
            Vector2 position = transform.position;
            Vector2 lookDirection = position - _rigidbody2D.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
            _rigidbody2D.rotation = angle;
        }
    }
}
