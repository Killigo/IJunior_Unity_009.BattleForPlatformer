using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;

    public float Attack()
    {
        return _damage;
    }
}
