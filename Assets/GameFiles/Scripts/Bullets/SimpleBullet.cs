
using UnityEngine;

public class SimpleBullet : MonoBehaviour, IBullet
{
    [SerializeField] private int _speed;
    [SerializeField] private float _timer;
    [SerializeField] private float _damage;
    [SerializeField] private SpriteRenderer _collissionEffect;

    private Rigidbody2D _rigidbody;
   
    public int Direction { get; set; }
    public float Damage { get => _damage; set => throw new System.NotImplementedException(); }

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
