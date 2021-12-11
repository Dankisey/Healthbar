using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent _healthChanged;

    private int _health;
    private int _damageRecieved;
    private int _healingRecieved;

    public int Health => _health;
    public int MaxHealth => _maxHealth;

    public event UnityAction HealthChanged
    {
        add => _healthChanged?.AddListener(value);
        remove => _healthChanged?.RemoveListener(value);
    }

    private void Start()
    {
        _health = _maxHealth;
        _damageRecieved = 10;
        _healingRecieved = 10;
    }
 
    public void TakeDamage()
    {
        _health -= _damageRecieved;

        if (_health < 0)
        {
            _health = 0;
            throw new System.Exception("Invalid value");
        }

        _healthChanged?.Invoke();
    }

    public void TakeHealing()
    {      
        _health += _healingRecieved;
        _health = _health > _maxHealth ? _maxHealth : _health;

        _healthChanged?.Invoke();
    }   
}