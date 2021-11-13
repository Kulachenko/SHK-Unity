using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private PlayerCollision _playerCollision;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Button _restartButton;

    private int _enemyKilledCount = 0;

    public event UnityAction GameOver;
    public event UnityAction GameStart;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(Restart);
        _playerCollision.EnemyKilled += OnEnemyKilled;
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(Restart);
        _playerCollision.EnemyKilled -= OnEnemyKilled;
    }

    private void Start()
    {
        Restart();
    }

    private void Restart()
    {
        _enemyKilledCount = 0;
        _gameOverScreen.Close();

        GameStart?.Invoke();
    }

    private void OnEnemyKilled()
    {
        _enemyKilledCount++;

        if(_enemyKilledCount == _enemySpawner.EnemiesCount)
        {
            _gameOverScreen.Open();

            GameOver?.Invoke();
        }
    }
}
