
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawners : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoint;
    private void FixedUpdate()
    {
        Spawn();
    }

    private void Spawn()
    {
        
    }
}
