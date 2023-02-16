
using System.Collections;
using UnityEngine;

public class SimpleBullet : MonoBehaviour, IBullet
{
    [SerializeField] private int _speed;
    private Rigidbody2D _rigidbody;
    private Vector2 _startPoint;
    public int Direction { get; set; }

    private void OnEnable()
    { 
        _startPoint = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Flying();
        SelfDestruction();
    }

    private void Flying()
    {
        _rigidbody.velocity = new Vector2(0, _speed * Direction);
    }

    private void SelfDestruction()
    {

        if (Vector2.Distance(_startPoint, transform.position) > 15)
        {
             gameObject.SetActive(false);
        }
    }

    
}
