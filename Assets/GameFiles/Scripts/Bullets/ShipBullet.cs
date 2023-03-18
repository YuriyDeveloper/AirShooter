using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBullet : Bullet, IBullet, IShipBullet
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private Rigidbody2D _rigidbody;

    private GameObject _mainPlayer;

    public float XDirection { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Collider2D MainPlayerCollider { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

   
    public void FlyToMainPlayer()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _mainPlayer = FindObjectOfType<MainPlayer>().gameObject;
        Vector3 direction = _mainPlayer.gameObject.transform.position - transform.position;
        _rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Damage(collider);
    }

    private void Damage(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<PlayerPlaneState>(out PlayerPlaneState mainPlayerState))
        {
            mainPlayerState.DecreaseHealth(_damage);
            Destroy();
        }
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
