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

    private Collider2D _collision;

    private void FixedUpdate()
    {
        ChekingMainPlayer();

        if (_collision)
        { 
            Vector3 vectorToTarget = _collision.gameObject.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - _rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * _speed);
        }
            
        
    }


    private void ChekingMainPlayer()
    {
        _collision = Physics2D.OverlapCircle(transform.position, _viewRadius, _layerMask);
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _viewRadius);
    }


}
