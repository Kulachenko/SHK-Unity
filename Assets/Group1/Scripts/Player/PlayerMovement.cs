using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCollision), typeof(KeyboardInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private float _speed;
    [SerializeField] private float _increasedSpeedTime;
    [SerializeField, Range(1, 2)] private float _accelerationCoefficient;

    private PlayerCollision _playerCollision;
    private KeyboardInput _keyboardInput;
    private float _lastSpeed;
    private int _speedIncreaseCounter = 0;
    private Vector2 _startPosition;
    private bool _gameStarted = false;

    private void Awake()
    {
        _playerCollision = GetComponent<PlayerCollision>();
        _keyboardInput = GetComponent<KeyboardInput>();
        _startPosition = transform.position;
    }

    private void OnEnable()
    {
        _game.GameStart += OnGameStart;
        _game.GameOver += OnGameOver;
        _playerCollision.IncreaseSpeed += OnIncreaseSpeed;
        _keyboardInput.Moooved += OnMooved;
    }

    private void OnDisable()
    {
        _game.GameStart -= OnGameStart;
        _game.GameOver -= OnGameOver;
        _playerCollision.IncreaseSpeed -= OnIncreaseSpeed;
        _keyboardInput.Moooved -= OnMooved;
    }

    private void SetNormalSpeed()
    {
        _lastSpeed = _speed;
        _speedIncreaseCounter = 0;
    }

    private void OnGameStart()
    {
        SetNormalSpeed();
        transform.position = _startPosition;
        _gameStarted = true;
    }

    private void OnGameOver()
    {
        _gameStarted = false;
    }

    private void OnIncreaseSpeed()
    {
        StartCoroutine(IncreaseSpeed());
    }

    private IEnumerator IncreaseSpeed()
    {
        _speedIncreaseCounter++;
        _lastSpeed *= _accelerationCoefficient;

        yield return new WaitForSeconds(_increasedSpeedTime);

        TryDecreaseSpeed();
    }

    private void TryDecreaseSpeed()
    {
        if (_speedIncreaseCounter > 0)
        {
            _lastSpeed /= _accelerationCoefficient;
            _speedIncreaseCounter--;
        }
    }

    private void OnMooved(Vector2 direction)
    {
        if(_gameStarted == true)
            transform.Translate(direction * _lastSpeed * Time.deltaTime);
    }
}
