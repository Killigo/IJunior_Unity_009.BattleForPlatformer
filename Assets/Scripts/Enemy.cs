using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private Collider2D _damageArea;
    [SerializeField] private Collider2D _attackArea;
    [SerializeField] private Player _player;
    [SerializeField, Range(0, 360)] private float _viewAngle = 70f;
    [SerializeField] private float _viewDistance = 10f;
    [SerializeField] private float _viewPointOffsetX;
    [SerializeField] private float _viewPointOffsetY;

    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;

    private Transform[] _wayPoints;
    private Transform _target;
    private int _currentPoint;
    private Vector3 _viewPoint;

    private int direction;

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
        //Slide(_target, Vector2.up);

        if (transform.position == _target.position)
            _currentPoint = (_currentPoint + 1) % _wayPoints.Length;
    }

    protected void Move(Transform target)
    {
        direction = (target.position.x - transform.position.x > 0) ? 0 : 180;

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        transform.rotation = Quaternion.AngleAxis(direction, Vector2.up);
    }

    //void Slide(Transform target, Vector3 railDirection)
    //{
    //    Vector3 heading = target.position - transform.position;
    //    Vector3 force = Vector3.Project(heading, railDirection);

    //    transform.Translate(force);
    //}

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

    private bool IsInView()
    {
        Color rayColor = Color.green;
        Vector3 viewPoint = transform.position + _viewPoint;

        float realAngle = Vector3.Angle(transform.right + _viewPoint, _player.transform.position - viewPoint);
        bool isView = false;

        if (realAngle >= _viewAngle / 2f && realAngle <= _viewAngle * 1.5f && Vector3.Distance(viewPoint, _player.transform.position) <= _viewDistance)
        {
            rayColor = Color.red;
            isView = true;
        }

        if(name == "Bear") Debug.Log($"{name}, {realAngle}");

        DrawViewState(viewPoint, rayColor);

        return isView;
    }

    private void DrawViewState(Vector3 viewPoint, Color rayColor)
    {
        Vector3 up = viewPoint + Quaternion.Euler(new Vector3(0, 0, _viewAngle / 2f)) * (transform.right * _viewDistance);
        Vector3 down = viewPoint + Quaternion.Euler(-new Vector3(0, 0, _viewAngle / 2f)) * (transform.right * _viewDistance);

        Debug.DrawLine(viewPoint, up, Color.yellow);
        Debug.DrawLine(viewPoint, down, Color.yellow);

        Debug.DrawLine(viewPoint, _player.transform.position, rayColor);
    }
}
