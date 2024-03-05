using UnityEngine;

public class VampireAbility : MonoBehaviour
{
    [SerializeField] private float _transferRadius = 5f;
    [SerializeField] private float _abilityDuration = 6f;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _transferRatePerSeconds = 5f;
    [SerializeField] private KeyCode _abilityKey = KeyCode.F;

    private float _transferTimer = 0f;
    private bool _isTransferring = false;
    private GameObject _targetEnemy;

    private void Update()
    {
        if (Input.GetKeyDown(_abilityKey))
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _transferRadius, _enemyLayer);

            foreach (Collider2D collider in hitColliders)
            {
                _targetEnemy = collider.gameObject;
                _isTransferring = true;
                _transferTimer = 0f;
            }
        }

        if (_isTransferring)
        {
            _transferTimer += Time.deltaTime;

            if (_transferTimer >= _abilityDuration)
            {
                _isTransferring = false;
                _targetEnemy = null;
            }
            else
                TransferHealth();
        }
    }

    private void TransferHealth()
    {
        if (_targetEnemy != null)
        {
            CharacterHealth enemyHealth = _targetEnemy.GetComponentInParent<CharacterHealth>();
            CharacterHealth playerHealth = GetComponent<CharacterHealth>();

            if (playerHealth != null && enemyHealth != null)
            {
                enemyHealth.TakeDamage(_transferRatePerSeconds * Time.deltaTime);
                playerHealth.Heal(_transferRatePerSeconds * Time.deltaTime);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _transferRadius);
    }
}
