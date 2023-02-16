
using System.Collections;
using UnityEngine;

public class SimpleBullet : MonoBehaviour, IBullet
{
    [SerializeField] private int _speed;
    private Rigidbody2D _rigidbody;
    private Vector2 _startPoint;
    public float _timer;
    public int Direction { get; set; }

    private void OnEnable()
    {
        _timer = 0;
        _startPoint = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
        Debug.Log("timer " + _timer);
        Flying();
        SelfDestruction();
    }

    private void Flying()
    {
        _rigidbody.velocity = new Vector2(0, _speed * Direction);
    }

    private void SelfDestruction()
    {

        if (_timer > 2)
        {
            gameObject.SetActive(false);
        }
    }

    
}
