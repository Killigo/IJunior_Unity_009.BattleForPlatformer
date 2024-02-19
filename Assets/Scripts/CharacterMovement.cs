using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    //private Rigidbody2D _rigidbody;

    //private void Start()
    //{
    //    _rigidbody = GetComponent<Rigidbody2D>();
    //}

    public void Move(float direction)
    {
        //Vector2 movement = new Vector2(direction, _rigidbody.velocity.y);
        //_rigidbody.velocity = movement * _speed;
        
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(direction, 0, 0), _speed * Time.deltaTime);

        direction = (direction > 0) ? 0 : 180;
        transform.rotation = Quaternion.AngleAxis(direction, Vector2.up);
    }

    public void Move(Transform target, bool isFly)
    {
        float direction = (target.position.x - transform.position.x > 0) ? 0 : 180;
        Vector2 walkPosition = (isFly) ? target.position : new Vector2(target.position.x, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, walkPosition, _speed * Time.deltaTime);
        transform.rotation = Quaternion.AngleAxis(direction, Vector2.up);
    }
}