using UnityEngine;

public class EnemyActionAfterDead : MonoBehaviour
{
    [SerializeField] private GameCoin _gameCoin;

    private Pool<GameCoin> _pool;
    public void SpawnCoin()
    {
        _pool = new Pool<GameCoin>(Instantiate(_gameCoin, transform.position, Quaternion.identity), 0);
        
    }
}
