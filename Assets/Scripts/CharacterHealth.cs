using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private float _minHealth = 0f;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        Debug.Log($"{name} {_currentHealth}");
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

        Debug.Log($"{name} {_currentHealth}");
    }

    public void Heal(float heal)
    {
        if (heal > 0)
            _currentHealth = Mathf.Clamp(_currentHealth + heal, _minHealth, _maxHealth);

        Debug.Log($"{name} {_currentHealth}");
    }

    private void Die()
    {
        Debug.Log($"{name} погибает.");
        Destroy(gameObject);
    }
}
