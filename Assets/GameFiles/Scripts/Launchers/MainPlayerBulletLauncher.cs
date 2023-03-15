using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerBulletLauncher : MonoBehaviour
{
    [SerializeField] private BulletContainer _bulletContainer;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<SpriteRenderer> _firePoints;

    
    private IBulletFactory _bulletFactory;

    private Pool<Bullet> _pool_1;
    private Pool<Bullet> _pool_2;
    private Pool<Bullet> _pool_3;
    private Pool<Bullet> _pool_4;

    private List<Pool<Bullet>> _poolList;

    private void Start()
    {
        _bulletFactory = Services.Container.Single<IBulletFactory>();
        StartLaunch();
    }

    public void StartLaunch()
    {
        _pool_1 = new Pool<Bullet>(_bulletFactory.CreateBullet(_bulletContainer.Container[0], true), 10);
        _pool_1.autoExpand = true;
        _pool_2 = new Pool<Bullet>(_bulletFactory.CreateBullet(_bulletContainer.Container[1], true), 10);
        _pool_2.autoExpand = true;
        _pool_3 = new Pool<Bullet>(_bulletFactory.CreateBullet(_bulletContainer.Container[2], true), 10);
        _pool_3.autoExpand = true;
        _pool_4 = new Pool<Bullet>(_bulletFactory.CreateBullet(_bulletContainer.Container[3], true), 10);
        _pool_4.autoExpand = true;

        _poolList = new List<Pool<Bullet>>();
        _poolList.Add(_pool_1);
        _poolList.Add(_pool_2);
        _poolList.Add(_pool_3);
        _poolList.Add(_pool_4);

        StopAllCoroutines();
        StartCoroutine(SpawnBullet());
        StopCoroutine(SpawnBullet());
        StartCoroutine(FirePoints());
        StopCoroutine(FirePoints());
    }

    private IEnumerator SpawnBullet()
    {
        while (gameObject.activeSelf)
        {
            int index = 0;
            foreach (Transform point in _spawnPoints)
            {
                IBullet bullet = _poolList[index].GetFreeElement(point.position);
                bullet.XDirection = _bulletContainer.XDirectionAngle[index];
                index++;
            }
            yield return new WaitForSeconds(_bulletContainer.SpawnInterval);
        }
    }

    private IEnumerator FirePoints()
    {
        while (gameObject.activeSelf)
        {
            foreach (SpriteRenderer sprite in _firePoints)
            {
                sprite.enabled = sprite.enabled ? false : true;
            }

             yield return new WaitForSeconds(_bulletContainer.SpawnInterval / 2);
        }
    }
}
