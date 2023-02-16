using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] private Direction _direction;
    private IBulletFactory _bulletFactory;

    private Pool<SimpleBullet> _poolOne;
    private void Start()
    {
        _bulletFactory = Services.Container.Single<IBulletFactory>();
        _poolOne = new Pool<SimpleBullet>(_bulletFactory.CreateSimpleBullet(), 100);
        _poolOne.autoExpand = autoExpand;
        StartCoroutine(CreateBullet());
        StopCoroutine(CreateBullet());
    }


    private IEnumerator CreateBullet()
    {
        while (gameObject.activeSelf)
        {
            foreach (Transform point in _spawnPoints)
            {
                IBullet bullet = _poolOne.GetFreeElement(point.transform.position);
                bullet.Direction = (int)_direction;
            }
            yield return new WaitForSeconds(_spawnInterval);
        }
       
    }
}
