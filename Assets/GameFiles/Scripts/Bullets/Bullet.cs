using UnityEngine;

public enum BulletIs
{
    enemy,
    player
}

public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private int _YDirection;
    [SerializeField] private int _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _lifeTime;
    [SerializeField] private SpriteRenderer _collissionEffect;

    private BulletIs _bulletIs;
    private float _timer;
    private int _XDirection = 3;

    private Rigidbody2D _rigidbody;

    public int Damage { get => _damage; set => throw new System.NotImplementedException(); }
    public BulletIs bulletIs { get => _bulletIs; set => _bulletIs = value; }

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
        Destroy(collider); 
    }

    private void Destroy(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Enemy>() && _bulletIs == BulletIs.enemy ||
            collider.gameObject.GetComponent<Player>() && _bulletIs == BulletIs.player)
        {
            return;
        }
        gameObject.SetActive(false);
    }

    private void Flying()
    {

        _rigidbody.velocity = new Vector2(2 * _XDirection , _speed * _YDirection);
    }

    private void SelfDestruction()
    {
        if (_timer > _lifeTime)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetXDirection(int direction)
    {
        _XDirection = direction;
    }

}
