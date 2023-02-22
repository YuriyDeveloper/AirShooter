using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPlaneState : MonoBehaviour, IPlaneState
{
    [SerializeField] private float _health;
    public float Health { get => _health; set => _health = value; }

    private void Update()
    {
        Destroy();
    }

    private void Destroy()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
