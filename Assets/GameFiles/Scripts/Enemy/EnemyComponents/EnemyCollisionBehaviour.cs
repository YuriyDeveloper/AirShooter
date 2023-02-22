using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionBehaviour : MonoBehaviour
{
    private EnemyPlaneState _enemyPlaneState;

    private void Start()
    {
        _enemyPlaneState = GetComponent<EnemyPlaneState>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IBullet takeBullet = collision.gameObject.GetComponent<IBullet>();
        if (collision != null && takeBullet as SimpleBullet)
        {
            TakeDamage(takeBullet.Damage, collision);
        }
    }

    private void TakeDamage(float damage, Collision2D collision)
    {
        if (_enemyPlaneState != null)
        {
            _enemyPlaneState.Health -= damage;
        }
    }
}
