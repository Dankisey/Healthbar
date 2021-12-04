using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _changingDelta;
    [SerializeField] private float _healthbarUpdatingTime;

    private Slider _healthbar;

    private void Start()
    {
        _healthbar = GetComponent<Slider>();    
    }

    public void SetMaxValue(int maxHealth)
    {
        _healthbar.maxValue = maxHealth;
        _healthbar.value = maxHealth;
    }

    public void ChangeValue()
    {
        StartCoroutine(ChangeHealthbarValue());
    }

    private IEnumerator ChangeHealthbarValue()
    {
        var waitForSomeSeconds = new WaitForSeconds(_healthbarUpdatingTime);

        while (_healthbar.value != _player.Health)
        {
            _healthbar.value = Mathf.MoveTowards(_healthbar.value, _player.Health, _changingDelta);

            yield return waitForSomeSeconds;
        }
    }
}
