using UnityEngine;

public class LastingDamageEffect : MonoBehaviour, IDamage
{
    [SerializeField] private GameObject _effect;
    [SerializeField] private Transform _spawnPoint;

    public void DamageEffect()
    {
        GameObject effect = Instantiate(_effect, gameObject.transform);
        effect.transform.position = new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, -5);
        
    }
}
