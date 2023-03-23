using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _slider;

    public void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _slider.maxValue = maxHealth;
        _slider.minValue = 0f;
        _slider.value = currentHealth;
    }
}
