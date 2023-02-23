using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum BulletType
{
    MainPlayer,
    MainPlayerAssistent,
    Enemy,
}

enum Direction
{
    MainPlayer = 1,
    Enemy = -1
}

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private List<Transform> _spawnPoints;

    [SerializeField] private BulletType _bulletType;
    [SerializeField] private Direction _direction;
    private IBulletFactory _bulletFactory;

    private Pool<SimpleBullet> _pool;
    private void Start()
    {
        _bulletFactory = Services.Container.Single<IBulletFactory>();
        _pool = new Pool<SimpleBullet>(_bulletFactory.CreateSimpleBullet(_bulletType), 100);
        _pool.autoExpand = autoExpand;
        StartCoroutine(CreateBullet());
        StopCoroutine(CreateBullet());
    }


    private IEnumerator CreateBullet()
    {
        while (gameObject.activeSelf)
        {
            foreach (Transform point in _spawnPoints)
            {
                IBullet bullet = _pool.GetFreeElement(point.transform.position);
                bullet.Direction = (int)_direction;
            }
            yield return new WaitForSeconds(_spawnInterval);
        }
       
    }
}
