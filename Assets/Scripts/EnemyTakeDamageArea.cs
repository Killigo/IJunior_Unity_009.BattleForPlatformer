using UnityEngine;

public class EnemyTakeDamageArea : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent(typeof(PlayerHealth)))
        {
            float damage = collision.gameObject.GetComponent<PlayerHealth>().Attack();
            _enemy.GetComponentInChildren<EnemyHealth>().TakeDamage(damage);
        }
    }
}
