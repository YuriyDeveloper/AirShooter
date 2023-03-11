using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionBehaviour : MonoBehaviour
{
    private EnemyPlaneState _enemyPlaneState;

    private void OnEnable()
    {
        _enemyPlaneState = GetComponent<EnemyPlaneState>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        IBullet takeBullet = collider.gameObject.GetComponent<IBullet>();
        if (collider != null && takeBullet as Bullet)
        {
            TakeDamage(takeBullet.Damage, collider);
        }
    }

    private void TakeDamage(float damage, Collider2D collision)
    {
        if (_enemyPlaneState != null)
        {
            _enemyPlaneState.Health -= damage;
        }
    }
}
