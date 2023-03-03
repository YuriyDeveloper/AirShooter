using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum Direction
{
    up = 1,
    down = -1,
}

enum directionAngle
{
    left, 
    right
}

public class BulletLauncher : MonoBehaviour
{
    [SerializeField] private Direction _direction;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private bool autoExpand = false;
   
    private IBulletFactory _bulletFactory;

    private Pool<Bullet> _pool;

    private void Start()
    {
        _bulletFactory = Services.Container.Single<IBulletFactory>();
        _pool = new Pool<Bullet>(_bulletFactory.CreateBullet(_bulletPrefab, (int)_direction), 30);
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
