using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthObject = 100f;

    private float _minHealth = 0f;

    public float Current { get; private set; }
    public float Max { get; private set; }

    public event Action CharecterDied;
    public event Action<float, float> HealthChanged;

    private void Awake()
    {
        Max = _healthObject;
        Current = Max;
    }

    public void TakeDamage(int amount)
    {
        if (Current <= _minHealth)
        {
            Destroy(gameObject);
            return;
        }

        UpdateHealth(-amount);
    }

    public void Heal(int healthImproving)
    {
        if (healthImproving >= Max)
        {
            _healthObject = Max;
        }

        UpdateHealth(healthImproving);
    }

    private void UpdateHealth(int healthChange)
    {
        Current = Mathf.Clamp(Current + healthChange, _minHealth, Max);
        HealthChanged?.Invoke(Current, Max);

        if (Current <= _minHealth)
        {
            CharecterDied?.Invoke();
        }
    }
}
