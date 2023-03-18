using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBulletLauncher : MonoBehaviour, IBulletLauncher
{
    [SerializeField] private BulletContainer _bulletContainer;
    [SerializeField] private List<Transform> _spawnPoints;

    private IBulletFactory _bulletFactory;

    private Pool<Bullet> _pool;
    private List<Pool<Bullet>> _poolList;


    public void StartLaunch()
    {
        _bulletFactory = Services.Container.Single<IBulletFactory>();
        _pool = new Pool<Bullet>(_bulletFactory.CreateBullet(_bulletContainer.Container[0], true), 10);
        _poolList = new List<Pool<Bullet>>();
        _poolList.Add(_pool);
        StartCoroutine(SpawnBullet());
        StopCoroutine(SpawnBullet());
    }

    private IEnumerator SpawnBullet()
    {
        while (gameObject.activeSelf)
        {
            int index = 0;
            foreach (Transform point in _spawnPoints)
            {
                Bullet bullet = _poolList[index].GetFreeElement(point.position);
                IShipBullet shipBullet = bullet as IShipBullet;
                shipBullet.FlyToMainPlayer();

                index++;
            }
            yield return new WaitForSeconds(_bulletContainer.SpawnInterval);
        }
    }
}
