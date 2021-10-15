using Scripts.GameBalance;
using System;
using UnityEngine;

public class GameData 
{
    public event Action EndGame;
    public int Health
    {
        get { return _health; }
    }

    public int Score
    {
        get { return _score; }
    }

    private int _health;
    private int _score;
    private int _maxHealth;
    private int _healthIncrement;

    public void Init()
    {
        ClearScore();
        SetStartHealth();
        _maxHealth = GameBalance.Instance.MaxHealth;
    }

    public void ClearScore()
    {
        _score = 0;
    }

    public void SetStartHealth()
    {
        _health = GameBalance.Instance.BeginHealth;
    }

    public void ChangeScore(int value, bool adding)       
    {
        if (!adding)
        {
            value *= -1;
        }
        _score += value;
    }

    public void ChangeHealth(bool adding)
    {
        if (adding) { _healthIncrement = GameBalance.Instance.HealthPoint; }
        else { _healthIncrement = -GameBalance.Instance.HealthPoint; }

        _health = Mathf.Min(_health + _healthIncrement, _maxHealth);

        if (_health <= 0)
        {
            EndGame?.Invoke();
        }
    }
}
