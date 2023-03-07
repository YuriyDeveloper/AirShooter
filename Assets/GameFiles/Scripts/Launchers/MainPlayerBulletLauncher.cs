using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerBulletLauncher : MonoBehaviour
{
    [SerializeField] private List<GameObject> _bulletContainer;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _spawnInterval;
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
        _pool_1 = new Pool<Bullet>(_bulletFactory.CreateBullet(_bulletContainer[0], true), 10);
        _pool_1.autoExpand = true;
        _pool_2 = new Pool<Bullet>(_bulletFactory.CreateBullet(_bulletContainer[1], true), 10);
        _pool_2.autoExpand = true;
        _pool_3 = new Pool<Bullet>(_bulletFactory.CreateBullet(_bulletContainer[2], true), 10);
        _pool_3.autoExpand = true;
        _pool_4 = new Pool<Bullet>(_bulletFactory.CreateBullet(_bulletContainer[3], true), 10);
        _pool_4.autoExpand = true;

        _poolList = new List<Pool<Bullet>>();
        _poolList.Add(_pool_1);
        _poolList.Add(_pool_2);
        _poolList.Add(_pool_3);
        _poolList.Add(_pool_4);

        StopAllCoroutines();
        StartCoroutine(CreateBullet());
        StopCoroutine(CreateBullet());
    }

    private IEnumerator CreateBullet()
    {
        while (gameObject.activeSelf)
        {
            int index = 0;
            foreach (Transform point in _spawnPoints)
            {
                
                IBullet bullet = _poolList[index].GetFreeElement(point.position);
                index++;
            }
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}
