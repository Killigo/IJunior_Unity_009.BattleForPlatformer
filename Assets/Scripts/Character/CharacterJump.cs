using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class CharacterJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }
}