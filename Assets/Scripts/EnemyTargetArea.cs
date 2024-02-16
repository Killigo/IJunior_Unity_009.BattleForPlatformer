using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetArea : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent(typeof(Player)))
        {
            _enemy.IsAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent(typeof(Player)))
        {
            _enemy.IsAttack = false;
        }
    }
}
