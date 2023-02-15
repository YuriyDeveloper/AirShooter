using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private Transform _spawnPointOne;
    [SerializeField] private Transform _spawnPointTwo;

    private IBulletFactory _bulletFactory;
    [SerializeField] private SimpleBullet _simpleBullet;

    private Pool<SimpleBullet> _poolOne;
    private Pool<SimpleBullet> _poolTwo;

    private void Start()
    {

        _bulletFactory = Services.Container.Single<IBulletFactory>();
        _poolOne = new Pool<SimpleBullet>(_bulletFactory.CreateSimpleBullet(), 0, _spawnPointOne);
        _poolTwo = new Pool<SimpleBullet>(_bulletFactory.CreateSimpleBullet(), 0, _spawnPointTwo);
        _poolOne.autoExpand = autoExpand;
        _poolTwo.autoExpand = autoExpand;

        StartCoroutine(CreateBullet());
    }

    private void Update()
    {
       
    }

    private IEnumerator CreateBullet()
    {
        while (gameObject.activeSelf)
        { 
            var bulletOne = this._poolOne.GetFreeElement();
            var bulletTwo = this._poolTwo.GetFreeElement();
            bulletOne.transform.parent = null;
            bulletTwo.transform.parent = null;
            yield return new WaitForSeconds(0.2f);
        }
       
    }
}
