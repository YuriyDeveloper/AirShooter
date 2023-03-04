using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerBulletLauncher : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private bool autoExpand = false;

    private IBulletFactory _bulletFactory;

    private Pool<Bullet> _pool;

    private void Start()
    {
        _bulletFactory = Services.Container.Single<IBulletFactory>();
        
    }

    public void TakeBulletType(GameObject bullet)
    {
        _pool = null;
        _pool = new Pool<Bullet>(_bulletFactory.CreateBullet(bullet), 30);
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
