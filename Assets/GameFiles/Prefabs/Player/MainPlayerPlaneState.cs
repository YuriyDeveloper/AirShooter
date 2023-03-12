using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerPlaneState : MonoBehaviour, IPlaneState
{
    [SerializeField] private float _health;
    [SerializeField] GameObject _collisionExplosionAnimation;

    public float Health { get => _health; set => _health = value; }

    private void Update()
    {
        Destroy();
    }

    private void Destroy()
    {

        if (_health <= 0)
        {
            if (_collisionExplosionAnimation)
            {
                GameObject destroyEffect = Instantiate(_collisionExplosionAnimation, transform.position, Quaternion.identity, null);
            }

            Destroy(gameObject);
        }
    }
}
