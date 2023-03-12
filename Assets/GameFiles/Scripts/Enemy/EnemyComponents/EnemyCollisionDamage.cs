using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDamage : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage(collision);
    }

    private void Damage(Collider2D collisison)
    {
        if (collisison.gameObject.GetComponent<MainPlayerState>())
        {
            collisison.GetComponent<MainPlayerState>().Health -= GetComponent<EnemyPlaneData>().CollisionDamage;
        }
    }
}
