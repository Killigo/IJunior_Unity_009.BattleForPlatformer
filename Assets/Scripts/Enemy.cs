using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Collider2D _damageArea;
    [SerializeField] private Collider2D _attackArea;
    [SerializeField] private Collider2D _lookArea;
    [SerializeField] private Player _player;
    [SerializeField, Range(0, 360)] private float _viewAngle = 90f;
    [SerializeField] private float _viewDistance = 15f;

    private Transform[] _points;
    private Transform _target;
    private int _currentPoint;
    private int directionSide;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) < 5)
        {
            _target = _player.transform;
        }
        else
        {
            _target = _points[_currentPoint];
        }

        DrawViewState();
        Move(_target);

        if (transform.position == _target.position)
            _currentPoint = (_currentPoint + 1) % _points.Length;
    }

    private void Move(Transform target)
    {
        directionSide = (target.position.x - transform.position.x > 0) ? 0 : 180;

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        transform.rotation = Quaternion.AngleAxis(directionSide, Vector2.up);
    }

    private void DrawViewState()
    {
        Vector2 up = transform.position + Quaternion.Euler(new Vector2(0, _viewAngle / 2f)) * (transform.forward * _viewDistance);
        Vector2 down = transform.position + Quaternion.Euler(-new Vector2(0, _viewAngle / 2f)) * (transform.forward * _viewDistance);
        Debug.DrawLine(transform.position, up, Color.yellow);
        Debug.DrawLine(transform.position, down, Color.yellow);
    }
}
