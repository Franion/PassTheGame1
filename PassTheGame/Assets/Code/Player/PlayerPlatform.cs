using System;
using System.Collections;
using UnityEngine;

public class PlayerPlatform : MonoBehaviour
{
    public Action<bool> OnColliderStateChange { get; set; }

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool _isColliding;

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!_isColliding)
        {
            _isColliding = true;
            OnColliderStateChange?.Invoke(_isColliding);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_isColliding)
        {
            _isColliding = false;
            OnColliderStateChange?.Invoke(_isColliding);
        }
    }
}