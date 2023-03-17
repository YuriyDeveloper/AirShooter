using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [SerializeField] private bool _toRotation;
    [SerializeField] private int _rotationValue;
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
        if (_rigidbody2D && _toRotation && GetComponent<EnemyBezierMove>().PathPoint < 1)
        {
            Vector2 position = transform.position;
            Vector2 lookDirection = position - _rigidbody2D.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - _rotationValue;
            _rigidbody2D.rotation = angle;
        }
    }
}
