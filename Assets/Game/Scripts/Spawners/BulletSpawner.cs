using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private List<Transform> _spawnPoints;
    private IBulletFactory _bulletFactory;

    private Pool<SimpleBullet> _poolOne;

    private void Start()
    {
        _bulletFactory = Services.Container.Single<IBulletFactory>();
        _poolOne = new Pool<SimpleBullet>(_bulletFactory.CreateSimpleBullet(), 50);
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
                IBullet bulletOne = _poolOne.GetFreeElement(point.transform.position);
              
            }
             yield return new WaitForSeconds(0.1f);
        }
       
    }
}
