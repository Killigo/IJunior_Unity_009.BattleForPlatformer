using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpForce = 5f;

    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private int _stateHash = Animator.StringToHash("State");
    private float _radius = 0.3f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _animator.SetInteger(_stateHash, 0);

        if (!InspectionGround())
            _animator.SetInteger(_stateHash, 2);

        if (Input.GetButton(Horizontal))
            Run();

        if (InspectionGround() && Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Run()
    {
        int direction = (Input.GetAxis(Horizontal) > 0) ? 0 : 180;

        if (InspectionGround())
            _animator.SetInteger(_stateHash, 1);

        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(Input.GetAxis(Horizontal), 0, 0), _speed * Time.deltaTime);
        transform.rotation = Quaternion.AngleAxis(direction, Vector2.up);
    }

    private void Jump()
    {
        _animator.SetInteger(_stateHash, 2);
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private bool InspectionGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius);
        return colliders.Length > 1;
    }
}