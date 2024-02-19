using UnityEngine;

[RequireComponent(typeof(CharacterAnimation))]
[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CharacterJump))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;

    private const string Horizontal = "Horizontal";

    private CharacterAnimation _playerAnimation;
    private CharacterMovement _playerMovement;
    private CharacterJump _playerJump;

    private float _radius = 0.15f;
    private float horizontalInput;

    private void Start()
    {
        _playerAnimation = GetComponent<CharacterAnimation>();
        _playerMovement = GetComponent<CharacterMovement>();
        _playerJump = GetComponent<CharacterJump>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis(Horizontal);

        _playerAnimation.SetIdle();

        if (Input.GetButton(Horizontal))
        {
            _playerMovement.Move(horizontalInput);
            _playerAnimation.SetRun();
        }

        if (InspectionGround() && Input.GetKeyDown(KeyCode.Space))
            _playerJump.Jump();
        else if (!InspectionGround())
            _playerAnimation.SetJump();
    }

    private bool InspectionGround()
    {
        return Physics2D.OverlapCircle(transform.position, _radius, _ground);
    }
}