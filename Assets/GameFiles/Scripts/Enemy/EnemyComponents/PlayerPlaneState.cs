using System.Collections;
using UnityEngine;

public class PlayerPlaneState : MonoBehaviour, IPlaneState
{
    [SerializeField] GameObject _collisionExplosionAnimation;
    [SerializeField] private float _health;
    [SerializeField] private SpriteRenderer _collisisonEffect;

    private LastingDamageEffect _lastingDamageEffect;

    private bool _canInstantiateLastingDamageEffect;
    public float Health { get => _health; set => _health = value; }

    private void OnEnable()
    {
        _canInstantiateLastingDamageEffect = true;
        _lastingDamageEffect = GetComponent<LastingDamageEffect>();
    }

    private void Update()
    {
        Debug.Log("enemy health is " + _health);
        Destroy();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(PlayCollisionEffect(collider));
        StopCoroutine(PlayCollisionEffect(collider));
    }

    private IEnumerator PlayCollisionEffect(Collider2D collider)
    {
        Damage();
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
        if (_lastingDamageEffect && _health < 10 && _canInstantiateLastingDamageEffect)
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
           
            Destroy(gameObject);
        }
    }




}
