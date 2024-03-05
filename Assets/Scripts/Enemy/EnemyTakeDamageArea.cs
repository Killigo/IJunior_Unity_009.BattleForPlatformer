using UnityEngine;

public class EnemyTakeDamageArea : MonoBehaviour
{
    private CharacterHealth _enemyHealth;

    private void Start()
    {
        _enemyHealth = GetComponentInParent<CharacterHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CharacterAttack characterAttack))
        {
            float damage = characterAttack.Attack();
            _enemyHealth.TakeDamage(damage);
        }
    }
}
