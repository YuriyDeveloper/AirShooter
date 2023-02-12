
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawners : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoint;
    private IBulletFactory _bulletFactory;
    private Services _services;

    private void Awake()
    {
        _bulletFactory = (IBulletFactory)_services.AllServices[ServicesKey._bulletFactory];
    }
    private void FixedUpdate()
    {
        Spawn();
    }

    private void Spawn()
    {
        if(Input.GetKey(KeyCode.Space))
        _bulletFactory.CreateSimpleBullet();

       
    }
}
