using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(EnemyWaypoints))]

public class EnemyController : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private bool _isFly = false;

    private CharacterMovement _enemyMovement;
    private EnemyWaypoints _enemyWaypoints;

    private Transform _target;
    private Transform _currentPoint;
    private bool _isAttack;

    private void Start()
    {
        _enemyMovement = GetComponent<CharacterMovement>();
        _enemyWaypoints = GetComponent<EnemyWaypoints>();

        _currentPoint = _enemyWaypoints.GetNextPosition();

        _isAttack = false;
    }

    private void Update()
    {
        if (_isAttack)
            _target = _player.transform;
        else
            _target = _currentPoint;

        _enemyMovement.Move(_target, _isFly);

        if (transform.position == _target.position)
            _currentPoint = _enemyWaypoints.GetNextPosition();
    }

    public void ChangeAttackAction(bool isAttack)
    {
        _isAttack = isAttack;
    }
}
