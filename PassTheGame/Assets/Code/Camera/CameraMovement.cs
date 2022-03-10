using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _baseCameraSpeed = 3f;

    [SerializeField] private float _minDirectionTime = 15f;
    [SerializeField] private float _maxDirectionTime = 30f;

    private Vector2 _currentDirection;
    private float _currentTime;
    private float _targetTime;

    private void Start()
    {
        _currentTime = 0f;

        _targetTime = UnityEngine.Random.Range(_minDirectionTime, _maxDirectionTime);
        _currentDirection = Vector2.up;
    }

    private void Update()
    {
        float speed = _baseCameraSpeed * Time.deltaTime;
        transform.position += (Vector3)_currentDirection * speed;

        UpdateTimer();
    }

    private void UpdateTimer()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _targetTime)
        {
            _currentTime -= _targetTime;
            _targetTime = UnityEngine.Random.Range(_minDirectionTime, _maxDirectionTime);

            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        int randomIndex = UnityEngine.Random.Range(0, 4);
        switch (randomIndex)
        {
            case 0:
                _currentDirection = Vector2.up;
                break;

            case 1:
                _currentDirection = Vector2.down;
                break;

            case 2:
                _currentDirection = Vector2.left;
                break;

            case 3:
                _currentDirection = Vector2.right;
                break;
        }
    }
}