using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    plane,
    rockets,
    boss
}

public enum EnemyPlaneType
{
    simplePlane,
    middlePlane,
    hardPlane
}

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private List<Transform> _spawnPoints;

    public EnemyType _enemyType;
    public EnemyPlaneType _enemyPlaneType;

    private IEnemyFactory _enemyFactory;

    private void Start()
    {
        Spawn();
    }
    private void Spawn()
    {
        foreach (Transform point in _spawnPoints)
        {
            
        }
    }
}
