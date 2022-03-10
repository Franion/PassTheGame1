using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Action<int> OnPlatformBuild { get; set; }

    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private PlayerPlatform _platformTransform;
    [SerializeField] private int _startingPlatformAmount = 3;

    private int _platformAmount;
    private bool _isAbleToBuild;

    private Color _redColor;
    private Color _greenColor;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;

        _platformAmount = _startingPlatformAmount;
        OnPlatformBuild?.Invoke(_platformAmount);
        _isAbleToBuild = false;

        _redColor = new Color(Color.red.r, Color.red.g, Color.red.b, 0.5f);
        _greenColor = new Color(Color.green.r, Color.green.g, Color.green.b, 0.5f);

        _platformTransform.SetColor(_redColor);
        _platformTransform.OnColliderStateChange = HandleColliderStateChange;
    }

    public void AddPlatforms(int amount)
    {
        _platformAmount += amount;
        OnPlatformBuild?.Invoke(_platformAmount);
    }

    private void HandleColliderStateChange(bool state)
    {
        _isAbleToBuild = !state;
        if (_isAbleToBuild)
        {
            _platformTransform.SetColor(_greenColor);
        }
        else
        {
            _platformTransform.SetColor(_redColor);
        }
    }

    private void Update()
    {
        Vector3 mousePosition = GetMousePosition();
        _platformTransform.transform.position = mousePosition;

        if (Input.GetMouseButtonDown(0) && _isAbleToBuild && _platformAmount > 0)
        {
            var newObject = Instantiate(_platformPrefab, mousePosition, Quaternion.identity);
            --_platformAmount;
            if (_platformAmount == 0)
            {
                _platformTransform.SetColor(_redColor);
            }

            OnPlatformBuild?.Invoke(_platformAmount);
        }
    }

    private Vector3 GetMousePosition()
    {
        return _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}