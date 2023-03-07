using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private int _lifeTime;
    [SerializeField] private int _YDirection;
    [SerializeField] private int _speed;
    [SerializeField] private int _damage;
    [SerializeField] private SpriteRenderer _collissionEffect;

     private float _timer;

    private int _XDirection;

    public int Damage { get => _damage; set => throw new System.NotImplementedException(); }

    private void OnEnable()
    {
        _timer = 0;
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
        transform.position += new Vector3(0, _speed * Time.deltaTime);
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
