using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent _healthChanged;

    private int _health;
    private int _damageRecieved;
    private int _healingRecieved;
    private bool _isAlive => _health > 0;

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
        if (_isAlive)
            _health -= _damageRecieved;

        _health = _health < 0 ? 0 : _health;

        _healthChanged?.Invoke();
    }

    public void TakeHealing()
    {      
        _health += _healingRecieved;
        _health = _health > _maxHealth ? _maxHealth : _health;

        _healthChanged?.Invoke();
    }   
}