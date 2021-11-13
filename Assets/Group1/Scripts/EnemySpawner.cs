using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform[] _enemiesPositions;
    [SerializeField] private Game _game;
    [SerializeField] private EnemyProperty[] _enemiesProperty;

    private List<Enemy> _enemies = new List<Enemy>();

    public int EnemiesCount { get; private set; }

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        _game.GameStart += OnGameStart;
    }

    private void OnDisable()
    {
        _game.GameStart -= OnGameStart;
    }

    private void Initialize()
    {
        for (int i = 0; i < _enemiesPositions.Length; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefab, _container);
            enemy.gameObject.SetActive(false);
            _enemies.Add(enemy);
        }

        EnemiesCount = _enemies.Count;
    }

    private void OnGameStart()
    {
        PlaceEnemiesOnPositions();
    }

    private void PlaceEnemiesOnPositions()
    {
        for (int i = 0; i < _enemiesPositions.Length; i++)
        {
            _enemies[i].transform.position = _enemiesPositions[i].transform.position;
            SetEnemyProperties(_enemies[i]);
            _enemies[i].gameObject.SetActive(true);
        }
    }

    private void SetEnemyProperties(Enemy enemy)
    {
        int propertyIndex = Random.Range(0, _enemiesProperty.Length);
        enemy.SetProperty(_enemiesProperty[propertyIndex]);
    }
}

[System.Serializable]
public class EnemyProperty
{
    [SerializeField] private string _label;
    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private Color _enemyColor;

    public EnemyType EnemyType => _enemyType;
    public Color EnemyColor => _enemyColor;
}
