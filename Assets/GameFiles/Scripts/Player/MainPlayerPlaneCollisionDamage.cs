using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerPlaneCollisionDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage(collision);
    }

    private void Damage(Collider2D collisison)
    {
        if (collisison.gameObject.GetComponent<EnemyState>())
        {
            collisison.GetComponent<EnemyState>().Health -= GetComponent<MainPlayerPlaneData>().CollisionDamage;
        }
    }
}
