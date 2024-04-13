using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHealthbar : Healthbar
{
    protected Slider Slider { get; private set; }

    protected override void OnHealthChanged()
    {
        float normalizedValue = Health.Value / Health.MaxValue;
        ChangeSliderValue(normalizedValue);
    }

    protected virtual void ChangeSliderValue(float normalizedValue)
    {
        Slider.value = normalizedValue;
    }

    private void Awake()
    {
        Slider = GetComponent<Slider>();
    }
}