using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBulletLauncher : MonoBehaviour, IBulletLauncher
{
    [SerializeField] private BulletContainer _bulletContainer;

    private IBulletFactory _bulletFactory;

    private Pool<ShipBullet> _pool;

    public void StartLaunch()
    {
       //.. _pool = new Pool<ShipBullet>(_bulletFactory.CreateBullet(_bulletContainer.Container[0], true), 10);
       // StartCoroutine(SpawnBullet());
       // StopCoroutine(SpawnBullet());
    }

    //private IEnumerator SpawnBullet()
    //{

    //}
}
