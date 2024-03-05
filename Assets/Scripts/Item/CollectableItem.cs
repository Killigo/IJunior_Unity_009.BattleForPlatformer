using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CollectableItem : MonoBehaviour
{
    private Animator _animator;
    private float _delay = 0.4f;
    private int _collectHash = Animator.StringToHash("isCollect");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            _animator.SetBool(_collectHash, true);
            Destroy(gameObject, _delay);
        }
    }
}
