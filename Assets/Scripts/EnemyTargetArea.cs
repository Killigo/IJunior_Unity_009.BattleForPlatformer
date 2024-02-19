using UnityEngine;

public class EnemyTargetArea : MonoBehaviour
{
    [SerializeField] private EnemyController _enemy;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent(typeof(PlayerController)))
        {
            _enemy.ChangeAttackAction(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent(typeof(PlayerController)))
        {
            _enemy.ChangeAttackAction(false);
        }
    }
}
