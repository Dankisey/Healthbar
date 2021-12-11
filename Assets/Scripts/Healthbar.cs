using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _changingDelta;
    [SerializeField] private float _updatingTime;

    private Slider _healthbar;

    private void OnEnable()
    {
        _player.HealthChanged += ChangeValue;
    }

    private void Start()
    {
        _healthbar = GetComponent<Slider>();

        _healthbar.maxValue = _player.MaxHealth;
        _healthbar.value = _player.MaxHealth;
    }

    public void ChangeValue()
    {
        StartCoroutine(ChangeHealthbarValue());
    }

    private IEnumerator ChangeHealthbarValue()
    {
        var waitForSomeSeconds = new WaitForSeconds(_updatingTime);

        while (_healthbar.value != _player.Health)
        {
            _healthbar.value = Mathf.MoveTowards(_healthbar.value, _player.Health, _changingDelta);

            yield return waitForSomeSeconds;
        }
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeValue;
    }
}
