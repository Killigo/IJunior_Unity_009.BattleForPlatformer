using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private Player _player;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private bool isFly = false;

    private Transform[] _wayPoints;
    private Transform _target;
    private int _currentPoint;
    private int direction;

    public bool IsAttack = false;

    private void Start()
    {
        _wayPoints = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _wayPoints[i] = _path.GetChild(i);
    }

    private void Update()
    {
        if (IsAttack)
            _target = _player.transform;
        else
            _target = _wayPoints[_currentPoint];

        Move(_target);

        if (transform.position == _target.position)
            _currentPoint = (_currentPoint + 1) % _wayPoints.Length;
    }

    private void Move(Transform target)
    {
        direction = (target.position.x - transform.position.x > 0) ? 0 : 180;

        Vector2 walkPosition = (isFly) ? target.position : new Vector2(target.position.x, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, walkPosition, _speed * Time.deltaTime);
        transform.rotation = Quaternion.AngleAxis(direction, Vector2.up);
    }
}
