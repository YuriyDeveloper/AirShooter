using UnityEngine;


public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private int _flyDirection;
    [SerializeField] private int _directionAngle;
    [SerializeField] private int _speed;
    [SerializeField] private float _timer;
    [SerializeField] private float _damage;
    [SerializeField] private SpriteRenderer _collissionEffect;

    private Rigidbody2D _rigidbody;

    

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
        _rigidbody.velocity = new Vector2(_directionAngle, _speed * _flyDirection);
    }

    private void SelfDestruction()
    {

        if (_timer > 2)
        {
            
            gameObject.SetActive(false);
        }
    }







   

}
