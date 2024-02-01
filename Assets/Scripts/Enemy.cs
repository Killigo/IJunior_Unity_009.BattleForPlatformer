using System.Linq.Expressions;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Collider2D _damageArea;
    [SerializeField] private Collider2D _attackArea;
    [SerializeField] private Player _player;
    [SerializeField, Range(0, 360)] private float _viewAngle = 70f;
    [SerializeField] private float _viewDistance = 10f;
    [SerializeField] private float _viewPointOffsetX;
    [SerializeField] private float _viewPointOffsetY;

    private Transform[] _points;
    private Transform _target;
    private int _currentPoint;
    private int directionSide;
    private Vector3 _eye;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i);

        _eye = new Vector3(_viewPointOffsetX, _viewPointOffsetY, 0);
    }

    private void Update()
    {
        if (IsInView())
        {
            _target = _player.transform;
        }
        else
        {
            _target = _points[_currentPoint];
        }

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

    private bool IsInView()
    {
        float realAngle = Vector3.Angle(transform.right + _eye, _player.transform.position - (transform.position + _eye));

        if (name == "Bear")
        {
            Debug.Log($"{realAngle} {_viewAngle} {name}");
        }

        Debug.DrawLine(transform.position + _eye, _player.transform.position, Color.red);
        DrawViewState();

        if (realAngle < _viewAngle / 2f && Vector3.Distance(transform.position + _eye, _player.transform.position) <= _viewDistance)
        {
            Debug.Log("TARGET");
        }
        /*
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position + _eye, _player.transform.position - (transform.forward + _eye), out hit, _viewDistance))
        {
            Debug.Log("RED");

            if (realAngle < _viewAngle / 2f && Vector3.Distance(transform.position + _eye, _player.transform.position) <= _viewDistance && hit.transform == _player.transform)
            {
                Debug.Log("TARGET");
                return true;
            }
        }
        */
        return false;
    }

    private void DrawViewState()
    {
        Vector3 eye = transform.position + _eye;
        Vector3 up = eye + Quaternion.Euler(new Vector3(0, 0, _viewAngle / 2f)) * (transform.right * _viewDistance);
        Vector3 down = eye + Quaternion.Euler(-new Vector3(0, 0, _viewAngle / 2f)) * (transform.right * _viewDistance);
        Debug.DrawLine(eye, up, Color.yellow);
        Debug.DrawLine(eye, down, Color.yellow);
    }
}
