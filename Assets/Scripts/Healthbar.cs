using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class Healthbar : MonoBehaviour
{
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

    public void ChangeValue(int health)
    {
        StartCoroutine(ChangeHealthbarValue(health));
    }

    private IEnumerator ChangeHealthbarValue(int health)
    {
        var waitForSomeSeconds = new WaitForSeconds(_healthbarUpdatingTime);

        while (_healthbar.value != health)
        {
            _healthbar.value = Mathf.MoveTowards(_healthbar.value, health, _changingDelta);

            yield return waitForSomeSeconds;
        }
    }
}
