using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;

    private int direction;

    protected void Move(Transform target)
    {
        direction = (target.position.x - transform.position.x > 0) ? 0 : 180;

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        transform.rotation = Quaternion.AngleAxis(direction, Vector2.up);
    }

    protected void TakeDamage(float damage)
    {
        if (damage < _health)
        {
            if (damage < 0)
                damage = 0;

            _health -= damage;
        }
        else
            Die();
    }

    protected float Attack()
    {
        return _damage;
    }

    private void Die()
    {
        Debug.Log($"{name} погибает.");
        Destroy(gameObject);
    }
}
