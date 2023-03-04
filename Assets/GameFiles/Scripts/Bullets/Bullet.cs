using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private int _YDirection;
    private int _XDirection;
    [SerializeField] private int _speed;
    [SerializeField] private float _timer;
    [SerializeField] private int _damage;
    [SerializeField] private SpriteRenderer _collissionEffect;

    private Rigidbody2D _rigidbody;

    public int Damage { get => _damage; set => throw new System.NotImplementedException(); }

    private void OnEnable()
    {
        _timer = 0;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
        Flying();
        SelfDestruction();
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(); 
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void Flying()
    {

        _rigidbody.velocity = new Vector2(2 * _XDirection , _speed * _YDirection);
    }

    private void SelfDestruction()
    {
        if (_timer > 2)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetXDirection(int direction)
    {
        _XDirection = direction;
    }

}
