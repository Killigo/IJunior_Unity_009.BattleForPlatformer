using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent(typeof(PlayerHealth)))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(_damage);
        }
    }
}
