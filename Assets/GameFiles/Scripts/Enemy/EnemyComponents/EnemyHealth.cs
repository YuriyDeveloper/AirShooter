using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IPlaneState
{
    [SerializeField] GameObject _explosionAnimation;
    [SerializeField] private float _health;
    [SerializeField] private SpriteRenderer _collisisonEffect;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        IBullet bullet = collider.GetComponent<IBullet>();
        if (bullet != null && bullet.Type == BulletType.mainPlayer)
        {
            DecreaseHealth(bullet.Damage);
            StartCoroutine(PlayCollisionEffect(collider));
            StopCoroutine(PlayCollisionEffect(collider));
        }
        
    }

    private IEnumerator PlayCollisionEffect(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("PlayerSimpleBullet") && _collisisonEffect)
        {
            _collisisonEffect.enabled = true;
            _collisisonEffect.gameObject.transform.position = collider.transform.position;
            yield return new WaitForSeconds(0.4f);
            _collisisonEffect.enabled = false;
        }
    }

    public void DecreaseHealth(float damageValue)
    {
        _health -= damageValue;
        Destroy();
    }

    private void Destroy()
    {
       
        if (_health <= 0)
        {
            if (_explosionAnimation)
            {
                GameObject destroyEffect = Instantiate(_explosionAnimation, transform.position, Quaternion.identity, null);
            }
            if (TryGetComponent<EnemyActionAfterDead>(out EnemyActionAfterDead component))
            {
                component.SpawnCoin();
            }
            Destroy(gameObject);
        }
    }

   
}
