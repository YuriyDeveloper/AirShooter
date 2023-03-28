
using UnityEngine;
using Zenject;

public class GameCoin : GameGift
{
    [SerializeField] private float _moveSpeed;

    private IGameData _gameData;

    private UICoinText _uiCoinText;

    [Inject]
    private void Construct(UICoinText uICoinText)
    {
        _uiCoinText = uICoinText;
    }

    private void Update()
    {
        transform.position += new Vector3(0, _moveSpeed * -1 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MainPlayer>())
        {
            _uiCoinText.SetCoinCount();

            gameObject.SetActive(false);
        }
    }

}