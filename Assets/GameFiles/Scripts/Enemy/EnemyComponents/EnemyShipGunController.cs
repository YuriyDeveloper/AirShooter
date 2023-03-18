using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipGunController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationModifier;
    [Range(1, 15)]
    [SerializeField] private float _viewRadius = 11;
    [SerializeField] private LayerMask _layerMask;

    private Collider2D _mainPlayerCollider;

    public Collider2D MainPlayerCollider { get => _mainPlayerCollider; }

    private void Start()
    {
        Shoot();

    }

    private void FixedUpdate()
    {
       // ChekingMainPlayer();

        //if (_mainPlayerCollider)
        //{ 
          //  Vector3 vectorToTarget = _mainPlayerCollider.gameObject.transform.position - transform.position;
            Vector3 vectorToTarget = FindObjectOfType<MainPlayer>().gameObject.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - _rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * _speed);
       // }
    }

    private void ChekingMainPlayer()
    {
        _mainPlayerCollider = Physics2D.OverlapCircle(transform.position, _viewRadius, _layerMask);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _viewRadius);
    }

    private void Shoot()
    {
        GetComponent<DefenseBulletLauncher>().StartLaunch();
    }
}
