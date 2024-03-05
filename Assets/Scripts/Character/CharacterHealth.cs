using UnityEngine;
using UnityEngine.Events;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private float _minHealth = 0f;
    private float _currentHealth;

    public UnityAction<float, float> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
            _currentHealth = Mathf.Clamp(_currentHealth - damage, _minHealth, _maxHealth);

        if (_currentHealth == _minHealth)
        {
            Die();
            return;
        }

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void Heal(float heal)
    {
        if (heal > 0)
            _currentHealth = Mathf.Clamp(_currentHealth + heal, _minHealth, _maxHealth);

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    private void Die()
    {
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
        gameObject.SetActive(false);
    }
}
