
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoint;
    private IBulletFactory _bulletFactory;
    private IObjectPool<SimpleBullet> _bulletPool;
    private IAssetProvider _assetProvider;
    private void Awake()
    {
        _bulletFactory = Services.Container.Single<IBulletFactory>();
        _bulletPool = new ObjectPool<SimpleBullet>(CreateBullet);
        _assetProvider = Services.Container.Single<IAssetProvider>();
    }
    private void FixedUpdate()
    {
        Spawn();
    }

    private SimpleBullet CreateBullet()
    {
        SimpleBullet bullet = Instantiate(_assetProvider.Load("Prefabs/Weapons/SimpleBullet"));
        return bullet;
    }

    private void Spawn()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _bulletFactory.CreateSimpleBullet();
        }
           

       
    }
}
