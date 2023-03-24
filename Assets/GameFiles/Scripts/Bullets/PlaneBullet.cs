using System.Collections;
using System.Diagnostics.Contracts;
using UnityEngine;


public enum BulletType
{
    enemy,
    mainPlayer
}

public class PlaneBullet : Bullet, IBullet
{
    [SerializeField] private int _lifeTime;
    [SerializeField] private int _yDirection;
    [SerializeField] private int _speed;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _tileEffect;
    [SerializeField] private BulletType _bulletType;

    private float _xRotation;

    private float _timer;

    private float _xDirection;

    public float XDirection { get => _xDirection; set => _xDirection = value; }
    public float XRotation { get => _xRotation; set => _xRotation = value; }

    private void OnEnable()
    {
        Debug.Log("RotationANgle" + _xRotation);
        transform.rotation = Quaternion.Euler(0, 0, _xRotation);
        _timer = 0;
        if (_tileEffect) { _tileEffect.SetActive(false); }
        StartCoroutine(ActivationTile());
        StopCoroutine(ActivationTile());
    }

    private void Start()
    {
        
    }

    private IEnumerator ActivationTile()
    {
        yield return new WaitForSeconds(0.1f);
        if (_tileEffect) { _tileEffect.SetActive(true); }
    }

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
        Flying();
        SelfDestruction();
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Damage(collider);
    }

    private void Damage(Collider2D collider)
    {
        if (_bulletType == BulletType.enemy && collider.gameObject.TryGetComponent<PlayerPlaneState>(out PlayerPlaneState mainPlayerState))
        {
            mainPlayerState.DecreaseHealth(_damage);
            Destroy(); 
        }
        else if (_bulletType == BulletType.mainPlayer && collider.gameObject.TryGetComponent<EnemyState>(out EnemyState enemyState))
        {
            enemyState.Health -= _damage;
            Destroy();
        }
    }

    private void Destroy()
    {
        
        gameObject.SetActive(false);
    }

    private void Flying()
    {
        transform.position += new Vector3(_xDirection, _yDirection * _speed * Time.deltaTime);
    }

    private void SelfDestruction()
    {
        if (_timer > _lifeTime)
        {
            if (_tileEffect) { _tileEffect.SetActive(false); }
            gameObject.SetActive(false);
        }
    }


}
