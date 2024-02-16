using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _damage = 5f;

    private float _health;

    private void Start()
    {
        _health = _maxHealth;
        Debug.Log($"{name} {_health}");
    }

    public void TakeDamage(float amount)
    {
        if (amount < _health)
        {
            if (amount < 0)
            {
                amount = 0;
            }

            _health -= amount;
            Debug.Log($"{name} {_health}");
        }
        else
        {
            Die();
        }
    }

    public float Attack()
    {
        return _damage;
    }

    private void Die()
    {
        Debug.Log($"{name} погибает.");
        Destroy(gameObject);
    }
}
