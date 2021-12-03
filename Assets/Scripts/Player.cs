using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Healthbar _healthbar;
    [SerializeField] private int _maxHealth;

    private int _health;
    private int _damageRecieved;
    private int _healingRecieved;

    private void Start()
    {
        _health = _maxHealth;
        _damageRecieved = 10;
        _healingRecieved = 10;

        _healthbar.SetMaxValue(_maxHealth);
    }
 
    public void TakeDamage()
    {
        _health -= _damageRecieved;
        _health = _health < 0 ? 0 : _health;

        _healthbar.ChangeValue(_health);
    }

    public void TakeHealing()
    {      
        _health += _healingRecieved;
        _health = _health > _maxHealth ? _maxHealth : _health;

        _healthbar.ChangeValue(_health);
    }   
}
