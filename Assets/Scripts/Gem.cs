using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Gem : MonoBehaviour
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
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _animator.SetBool(_collectHash, true);
            Destroy(gameObject, _delay);
        }
    }
}
