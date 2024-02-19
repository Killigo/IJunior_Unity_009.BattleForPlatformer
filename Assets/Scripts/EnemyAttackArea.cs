using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    private float _damage;

    private void Start()
    {
        _damage = GetComponentInParent<CharacterAttack>().Attack();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CharacterHealth health))
        {
            health.TakeDamage(_damage);
        }
    }
}
