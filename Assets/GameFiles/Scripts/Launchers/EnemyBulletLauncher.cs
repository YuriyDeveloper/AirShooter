using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyBulletLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private bool autoExpand = false;
   
    private IBulletFactory _bulletFactory;

    private Pool<PlaneBullet> _pool;

    private void Start()
    {
        _bulletFactory = Services.Container.Single<IBulletFactory>();
      //  _pool = new Pool<PlaneBullet>(_bulletFactory.CreateBullet(_bulletPrefab, true), 30);
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

            }
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}
