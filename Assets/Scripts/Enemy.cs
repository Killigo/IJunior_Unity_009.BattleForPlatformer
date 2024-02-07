using System.Linq.Expressions;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class Enemy : Character
{
    [SerializeField] private Transform _path;
    [SerializeField] private Collider2D _damageArea;
    [SerializeField] private Collider2D _attackArea;
    [SerializeField] private Player _player;
    [SerializeField, Range(0, 360)] private float _viewAngle = 70f;
    [SerializeField] private float _viewDistance = 10f;
    [SerializeField] private float _viewPointOffsetX;
    [SerializeField] private float _viewPointOffsetY;

    private Transform[] _wayPoints;
    private Transform _target;
    private int _currentPoint;
    private Vector3 _viewPoint;

    private void Start()
    {
        _wayPoints = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _wayPoints[i] = _path.GetChild(i);

        _viewPoint = new Vector3(_viewPointOffsetX, _viewPointOffsetY, 0);
    }

    private void Update()
    {
        if (IsInView())
            _target = _player.transform;
        else
            _target = _wayPoints[_currentPoint];

        Move(_target);

        if (transform.position == _target.position)
            _currentPoint = (_currentPoint + 1) % _wayPoints.Length;
    }

    private bool IsInView()
    {
        Vector3 viewPoint = transform.position + _viewPoint;
        Color rayColor = Color.green;

        float realAngle = Vector3.Angle(transform.right + _viewPoint, _player.transform.position - viewPoint);
        string message = "";
        bool isSee = false;
        
        if (name == "Bear")
            message += $"{realAngle} {_viewAngle} {name}";
        
        if (realAngle >= _viewAngle / 2f && realAngle <= _viewAngle * 1.5f && Vector3.Distance(viewPoint, _player.transform.position) <= _viewDistance)
        {
            message += " TARGET";
            rayColor = Color.red;
            isSee = true;
        }

        DrawViewState();
        Debug.DrawLine(viewPoint, _player.transform.position, rayColor);
        Debug.Log(message);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, _player.transform.position);

        if (hit.collider != null)
            Debug.Log(hit.collider.name);

        return isSee;
    }

    private void DrawViewState()
    {
        Vector3 viewPoint = transform.position + _viewPoint;
        Vector3 up = viewPoint + Quaternion.Euler(new Vector3(0, 0, _viewAngle / 2f)) * (transform.right * _viewDistance);
        Vector3 down = viewPoint + Quaternion.Euler(-new Vector3(0, 0, _viewAngle / 2f)) * (transform.right * _viewDistance);
        Debug.DrawLine(viewPoint, up, Color.yellow);
        Debug.DrawLine(viewPoint, down, Color.yellow);
    }
}
