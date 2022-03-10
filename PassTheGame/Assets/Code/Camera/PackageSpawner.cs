using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _packagePrefab;
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private float _spawnTime = 5f;

    private float _currentTime;

    private Vector2 _cubeSize;
    private Vector2 _cubeCenter;

    private void Start()
    {
        _currentTime = 0f;

        Transform cubeTrans = _collider.transform;
        _cubeCenter = cubeTrans.position;

        _cubeSize.x = cubeTrans.localScale.x * _collider.size.x;
        _cubeSize.y = cubeTrans.localScale.y * _collider.size.y;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _spawnTime)
        {
            _currentTime -= _spawnTime;
            Instantiate(_packagePrefab, GetRandomPosition(), Quaternion.identity);
        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 randomPosition = new Vector2(Random.Range(-_cubeSize.x / 2, _cubeSize.x / 2), Random.Range(-_cubeSize.y / 2, _cubeSize.y / 2));

        return _cubeCenter + randomPosition + (Vector2)transform.position;
    }
}