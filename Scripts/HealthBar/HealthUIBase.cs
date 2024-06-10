using UnityEngine;

public abstract class HealthUIBase : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    protected abstract void UpdateHealthUI(float currentHealth, float maxHealth);

    private void OnHealthChanged(float currentHealth, float maxHealth)
    {
        UpdateHealthUI(currentHealth, maxHealth);
    }
}
