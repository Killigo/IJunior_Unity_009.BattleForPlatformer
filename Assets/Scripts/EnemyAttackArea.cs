using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth health))
        {
            health.TakeDamage(_damage);
        }
    }
}
