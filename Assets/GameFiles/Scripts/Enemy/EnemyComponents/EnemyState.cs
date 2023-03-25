using System.Collections;
using UnityEngine;

public class EnemyState : MonoBehaviour, IPlaneState
{
    [SerializeField] GameObject _collisionExplosionAnimation;
    [SerializeField] private float _health;
    [SerializeField] private SpriteRenderer _collisisonEffect;

    private EnemyLastingDamageEffect _lastingDamageEffect;

    private bool _canInstantiateLastingDamageEffect;

    public float Health { get => _health; set => _health = value; }

    private void OnEnable()
    {
        _canInstantiateLastingDamageEffect = true;
        _lastingDamageEffect = GetComponent<EnemyLastingDamageEffect>();
    }

    private void Update()
    {
        Destroy();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Damage();
        StartCoroutine(PlayCollisionEffect(collider));
        StopCoroutine(PlayCollisionEffect(collider));
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

    private void Damage()
    {
        if (_lastingDamageEffect && _health < 20 && _canInstantiateLastingDamageEffect)
        {
            _canInstantiateLastingDamageEffect = false;
            _lastingDamageEffect.DamageEffect();
        }
    }


    private void Destroy()
    {
       
        if (_health <= 0)
        {
            if (_collisionExplosionAnimation)
            {
                GameObject destroyEffect = Instantiate(_collisionExplosionAnimation, transform.position, Quaternion.identity, null);
            }
            if (TryGetComponent<EnemyActionAfterDead>(out EnemyActionAfterDead component))
            {
                component.SpawnCoin();
            }
            Destroy(gameObject);
        }
    }

    public void DecreaseHealth(float damageValue)
    {
        throw new System.NotImplementedException();
    }
}
