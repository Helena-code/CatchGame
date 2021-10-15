using UnityEngine;
using System;
using Scripts.GameBalance;

public class PlayerMove : MonoBehaviour
{
    public event Action<Vector2> ChangedDirection;

    [SerializeField] private Rigidbody2D _rigidbody2D;

    private Vector2 _direction;
    private Vector2 _lastDirection;
    private float _speed;
    private int _screenWidth;

    private void Awake()
    {
        SetDefaultSpeed();
    }

    private void Start()
    {
        _screenWidth = Screen.width;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            SetDirection(mousePos);
            SaveLastDirection();
        }
        else _direction = Vector2.zero;
    }

    private void FixedUpdate()
    {
        Vector2 position = _rigidbody2D.position;
        position.x = position.x + _speed * _direction.x * Time.deltaTime;
        _rigidbody2D.MovePosition(position);
    }

    private void SetDirection(Vector3 pos)
    {
        if (pos.x < _screenWidth / 2)
        {
            _direction = Vector2.left;
            CheckChangeDirection();
            return;
        }
        _direction = Vector2.right;
        CheckChangeDirection();
    }

    private void CheckChangeDirection()
    {
        if (_lastDirection != _direction)
        {
            ChangedDirection?.Invoke(_direction);
        }
    }
    private void SaveLastDirection()
    {
        _lastDirection = _direction;
    }

    private void SetDefaultSpeed()
    {
        _speed = GameBalance.Instance.PlayerSpeed;
    }
}
