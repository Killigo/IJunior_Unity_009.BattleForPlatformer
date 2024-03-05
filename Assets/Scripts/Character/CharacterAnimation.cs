using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;
    private int _stateHash = Animator.StringToHash("State");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetIdle()
    {
        _animator.SetInteger(_stateHash, 0);
    }

    public void SetRun()
    {
        _animator.SetInteger(_stateHash, 1);
    }

    public void SetJump()
    {
        _animator.SetInteger(_stateHash, 2);
    }
}