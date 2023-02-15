
using System.Collections;
using UnityEngine;

public class SimpleBullet : MonoBehaviour, IBullet
{
    [SerializeField] private int _speed;
    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Flying();
        SelfDestruction();
    }

    private void Flying()
    {
        _rigidbody.velocity = new Vector2(0, _speed);
    }

    private void SelfDestruction()
    {

        if (transform.position.y > 2)
        {
             gameObject.SetActive(false);
        }
    }

    
}
