using System.Collections;
using UnityEngine;

public class EnemyPlaneState : MonoBehaviour, IPlaneState
{
    [SerializeField] GameObject _collisionExplosionAnimation;
    [SerializeField] private float _health;
    [SerializeField] private SpriteRenderer _collisisonEffect;
    public float Health { get => _health; set => _health = value; }

    private void Update()
    {
        Destroy();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
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
