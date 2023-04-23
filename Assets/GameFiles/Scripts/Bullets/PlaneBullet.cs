using System.Collections;
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

    public bool CanFly { get; set; }

    private float _xRotation;
    private float _timer;
    private float _xDirection;

    public float XDirection { get => _xDirection; set => _xDirection = value; }
    public float XRotation { get => _xRotation; set => transform.rotation = Quaternion.Euler(0, 0, value); }
    public int Damage { get => _damage; set => throw new System.NotImplementedException(); }
    public BulletType Type { get => _bulletType; set => throw new System.NotImplementedException(); }

    private void OnEnable()
    {
        _timer = 0;
        if (_tileEffect) { _tileEffect.SetActive(false); }
        StartCoroutine(ActivationTile());
        StopCoroutine(ActivationTile());
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
        Destroy(collider);
    }

    private void Destroy(Collider2D collider)
    {
        if (_bulletType == BulletType.mainPlayer && collider.GetComponent<Enemy>())
        {
            gameObject.SetActive(false);
        }
      
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
